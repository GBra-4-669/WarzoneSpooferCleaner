using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

public class Adapter
{
    public ManagementObject adapter;
    public string adaptername;
    public string customname;
    public int devnum;

    public Adapter(ManagementObject a, string aname, string cname, int n)
    {
        adapter = a;
        adaptername = aname;
        customname = cname;
        devnum = n;
    }

    public Adapter(NetworkInterface i) : this(i.Description) { }

    public Adapter(string aname)
    {
        adaptername = aname;

        var searcher = new ManagementObjectSearcher("select * from win32_networkadapter where Name='" + adaptername + "'");
        var found = searcher.Get();
        adapter = found.Cast<ManagementObject>().FirstOrDefault();

        // Extract adapter number; this should correspond to the keys under
        // HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}
        try
        {
            var match = Regex.Match(adapter.Path.RelativePath, "\\\"(\\d+)\\\"$");
            devnum = int.Parse(match.Groups[1].Value);
        }
        catch
        {
            return;
        }

        // Find the name the user gave to it in "Network Adapters"
        customname = NetworkInterface.GetAllNetworkInterfaces()
            .Where(i => i.Description == adaptername).Select(i => " (" + i.Name + ")")
            .FirstOrDefault();
    }

    /// <summary>
    /// Get the .NET managed adapter.
    /// </summary>
    public NetworkInterface ManagedAdapter
    {
        get
        {
            return NetworkInterface.GetAllNetworkInterfaces().Where(
                nic => nic.Description == this.adaptername
            ).FirstOrDefault();
        }
    }

    /// <summary>
    /// Get the MAC address as reported by the adapter.
    /// </summary>
    public string Mac
    {
        get
        {
            try
            {
                return BitConverter.ToString(this.ManagedAdapter.GetPhysicalAddress().GetAddressBytes()).Replace("-", "").ToUpper();
            }
            catch { return null; }
        }
    }

    /// <summary>
    /// Get the registry key associated to this adapter.
    /// </summary>
    public string RegistryKey
    {
        get
        {
            return String.Format(@"SYSTEM\ControlSet001\Control\Class\{{4D36E972-E325-11CE-BFC1-08002BE10318}}\{0:D4}", this.devnum);
        }
    }

    /// <summary>
    /// Get the NetworkAddress registry value of this adapter.
    /// </summary>
    public string RegistryMac
    {
        get
        {
            try
            {
                using (RegistryKey regkey = Registry.LocalMachine.OpenSubKey(this.RegistryKey, false))
                {
                    return regkey.GetValue("NetworkAddress").ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }

    /// <summary>a
    /// Sets the NetworkAddress registry value of this adapter.
    /// </summary>
    /// <param name="value">The value. Should be EITHER a string of 12 hexadecimal digits, uppercase, without dashes, dots or anything else, OR an empty string (clears the registry value).</param>
    /// <returns>true if successful, false otherwise</returns>
    public bool SetRegistryMac(string value)
    {
        bool shouldReenable = false;

        try
        {
            // If the value is not the empty string, we want to set NetworkAddress to it,
            // so it had better be valid
            if (value.Length > 0 && !IsValidMac(value, false))
                throw new Exception(value + " is not a valid mac address");

            using (RegistryKey regkey = Registry.LocalMachine.OpenSubKey(RegistryKey, true))
            {
                if (regkey == null)
                    throw new Exception("Failed to open the registry key");

                // Sanity check
                if (regkey.GetValue("AdapterModel") as string != adaptername
                    && regkey.GetValue("DriverDesc") as string != adaptername)
                    throw new Exception("Adapter not found in registry");

                // Attempt to disable the adepter
                var result = (uint)adapter.InvokeMethod("Disable", null);
                if (result != 0)
                    throw new Exception("Failed to disable network adapter.");

                // If we're here the adapter has been disabled, so we set the flag that will re-enable it in the finally block
                shouldReenable = true;

                // If we're here everything is OK; update or clear the registry value
                if (value.Length > 0)
                    regkey.SetValue("NetworkAddress", value, RegistryValueKind.String);
                else
                    regkey.DeleteValue("NetworkAddress");


                return true;
            }
        }

        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return false;
        }

        finally
        {
            if (shouldReenable)
            {
                uint result = (uint)adapter.InvokeMethod("Enable", null);
                if (result != 0)
                    MessageBox.Show("Failed to re-enable network adapter.");
            }
        }
    }

    public override string ToString()
    {
        return adaptername + customname;
    }

    /// <summary>
    /// Get a random (locally administered) MAC address.
    /// </summary>
    /// <returns>A MAC address having 01 as the least significant bits of the first byte, but otherwise random.</returns>
    public static string GetNewMac()
    {
        Random r = new Random();
        byte[] bytes = new byte[6];
        r.NextBytes(bytes);

        // Set second bit to 1
        bytes[0] = (byte)(bytes[0] | 0x02);
        // Set first bit to 0
        bytes[0] = (byte)(bytes[0] & 0xfe);

        return MacToString(bytes);
    }

    /// <summary>
    /// Verifies that a given string is a valid MAC address.
    /// </summary>
    /// <param name="mac">The string.</param>
    /// <param name="actual">false if the address is a locally administered address, true otherwise.</param>
    /// <returns>true if the string is a valid MAC address, false otherwise.</returns>
    public static bool IsValidMac(string mac, bool actual)
    {
        // 6 bytes == 12 hex characters (without dashes/dots/anything else)
        if (mac.Length != 12)
            return false;

        // Should be uppercase
        if (mac != mac.ToUpper())
            return false;

        // Should not contain anything other than hexadecimal digits
        if (!Regex.IsMatch(mac, "^[0-9A-F]*$"))
            return false;

        if (actual)
            return true;

        // If we're here, then the second character should be a 2, 6, A or E
        char c = mac[1];
        return (c == '2' || c == '6' || c == 'A' || c == 'E');
    }

    /// <summary>
    /// Verifies that a given MAC address is valid.
    /// </summary>
    /// <param name="mac">The address.</param>
    /// <param name="actual">false if the address is a locally administered address, true otherwise.</param>
    /// <returns>true if valid, false otherwise.</returns>
    public static bool IsValidMac(byte[] bytes, bool actual)
    {
        return IsValidMac(MacToString(bytes), actual);
    }

    /// <summary>
    /// Converts a byte array of length 6 to a MAC address (i.e. string of hexadecimal digits).
    /// </summary>
    /// <param name="bytes">The bytes to convert.</param>
    /// <returns>The MAC address.</returns>
    public static string MacToString(byte[] bytes)
    {
        return BitConverter.ToString(bytes).Replace("-", "").ToUpper();
    }
}