using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace Spoof
{
    internal class SpooferFns
    {
        static readonly Random random = new Random();
        readonly modestGieikCleaner.AppForm appForm;

        public SpooferFns(modestGieikCleaner.AppForm form)
        {
            appForm = form;
        }

        public void CleanTracers()
        {
            
            string wzDir = RequestPath("Please locate your MW .exe file", @"C:\Program Files (x86)\Call of Duty Modern Warfare");
            string localAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string programDataDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            try
            {
                Empty( Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Call of Duty Modern Warfare");

                appForm.AppendText("done with user directories");

                foreach (string possiblePath in Constants.wzPaths)
                {
                    Empty($@"{wzDir}\{possiblePath}");
                }

                appForm.AppendText("done with wz directories");

                foreach (string possiblePath in Constants.localAppDataPaths)
                {
                    Empty($@"{localAppDataDir}\{possiblePath}");
                }

                appForm.AppendText("done with Local App Data directories");

                foreach (string possiblePath in Constants.appDataPaths)
                {
                    Empty($@"{appDataDir}\{possiblePath}");
                }

                appForm.AppendText("done with App Data directories");

                foreach (string possiblePath in Constants.programDataPaths)
                {
                    Empty($@"{programDataDir}\{possiblePath}");
                }

                appForm.AppendText("done with Program Data directories");

                foreach (string possiblePath in Constants.userAgnosticPaths)
                {
                    Empty(possiblePath);
                }

                appForm.AppendText("done with user agnostic directories");

                appForm.AppendText("\nSUCCESSFULLY CLEANED TRACERS\n", Color.Lime);
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                appForm.AppendText(dirNotFound.Message + "\n");
            }
        }

        public void CleanHKeys()
        {
            Guid guid = Guid.NewGuid();

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true))
            {
                foreach (string subkey in key.GetSubKeyNames())
                {
                    if (subkey == "Blizzard Entertainment")
                    {
                        key.DeleteSubKeyTree(subkey);
                    }
                }
                key.Close();
            }

            using (RegistryKey subkey = Registry.LocalMachine
                .OpenSubKey(@"SYSTEM\CurrentControlSet\Control\IDConfigDB\Hardware Profiles\0001", true))
            {
                if (subkey != null)
                {
                    string user = $@"{Environment.UserDomainName}\{Environment.UserName}";
                    RegistrySecurity rs = new RegistrySecurity();
                    rs.AddAccessRule(new RegistryAccessRule(user,
                        RegistryRights.FullControl,
                        InheritanceFlags.None,
                        PropagationFlags.None,
                        AccessControlType.Allow));
                    subkey.SetAccessControl(rs);
                    subkey.SetValue("HwProfileGuid", "{" + guid + "}", RegistryValueKind.String);
                    subkey.Close();
                }
            }

            using (RegistryKey subkey = Registry.LocalMachine
                 .OpenSubKey(@"SOFTWARE\Microsoft\Cryptography", true))
            {
                if (subkey != null)
                {
                    string user = $@"{Environment.UserDomainName}\{Environment.UserName}";
                    RegistrySecurity rs = new RegistrySecurity();
                    rs.AddAccessRule(new RegistryAccessRule(user,
                        RegistryRights.FullControl,
                        InheritanceFlags.None,
                        PropagationFlags.None,
                        AccessControlType.Allow));
                    subkey.SetAccessControl(rs);
                    subkey.SetValue("MachineGuid", guid, RegistryValueKind.String);
                    subkey.Close();
                }
            }

            appForm.AppendText("\nSUCCESSFULLY CLEANED HKEYS\n", Color.Lime);
        }

        public void SpoofBIOS()
        {
            using (Process process = new Process())
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory,
                };
                process.StartInfo = psi;
                process.OutputDataReceived += (sender, e) => { appForm.AppendText(e.Data + "\n"); };
                process.ErrorDataReceived += (sender, e) => { appForm.AppendText(e.Data + "\n"); };
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                using (StreamWriter sw = process.StandardInput)
                {
                    const string DE = "AMIDEWINx64 ";
                    sw.WriteLine($@"{DE}/BS {GetRandomString(16)}");
                    sw.WriteLine($@"{DE}/SU {Guid.NewGuid().ToString("N")}");
                    sw.WriteLine($@"{DE}/SS {GetRandomString(16)}");
                    sw.WriteLine($@"{DE}/CS {GetRandomString(16)}");
                }
                process.WaitForExit();
                appForm.AppendText("\nSUCCESSFULLY SPOOFED BIOS\n", Color.Lime);
            }
        }

        public void SpoofMAC()
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces()
                .Where(a => Adapter.IsValidMac(a.GetPhysicalAddress().GetAddressBytes(), true))
                .OrderByDescending(a => a.Speed))
            {
                Adapter adpt = new Adapter(adapter);
                string newMac = Adapter.GetNewMac();

                if (!Adapter.IsValidMac(newMac, false))
                {
                    MessageBox.Show("MAC-address is not valid - try again to spoof MAC address", "Wrong MAC-address autocreated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    appForm.AppendText("\nERROR\n MAC ADDRESS SPOOFING FAILED \n", Color.Red);
                    return;
                }

                appForm.AppendText($"Current MAC Address: {adpt.Mac}\n");
                appForm.AppendText($"Your MAC Address (if it will pass validity checks): {newMac}\n");
                adpt.SetRegistryMac(newMac);
                appForm.AppendText("\nSUCCESSFULLY SPOOFED MACs\n", Color.Lime);
            }
        }

        public void SpoofVolumesID()
        {
            string[] DriveList = Environment.GetLogicalDrives();

            foreach (string drive in DriveList)
            {
                using (Process pProcess = new Process())
                {
                    string newID = $"{GetRandomHexNumber(4)}-{GetRandomHexNumber(4)}";
                    pProcess.StartInfo.FileName = "cmd.exe";
                    pProcess.StartInfo.UseShellExecute = false;
                    pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    pProcess.StartInfo.CreateNoWindow = true;
                    pProcess.StartInfo.Arguments = $@"/c volumeid {drive[0]}: {newID}";
                    pProcess.Start();
                    appForm.AppendText($"new ID of drive {drive[0]} is {newID}");
                    pProcess.WaitForExit();
                }
            }
            appForm.AppendText("\nSUCCESSFULLY SPOOFED HDDs\n", Color.Lime);
        }

        //TRACERS FNs

        private string RequestPath(string message, string defaultPath)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                RestoreDirectory = true
            };
            dialog.Title = message;
            string resultPath;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                resultPath = dialog.FileName;
            }
            else
            {
                resultPath = defaultPath;
                appForm.AppendText($"You did not pass the folder...\n using default path: {resultPath}");
            }
            dialog.Dispose();
            return resultPath;
        }


        private void Empty(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                Directory.Delete(dirPath, true);
            }
        }

        // volume id fns
        public static string GetRandomHexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }

        // bios spoof fns

        public static string GetRandomString(int length)
        {
            const string chars = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}



/* REJECTED CANDIDATES:
 * 
 *             //del ".\main\data0.dcache"
 *           //del ".\main\data1.dcache"
 *           //del ".\main\toc0.dcache"
 *           //del ".\main\toc1.dcache"
 *           //del ".\Data\data\shmem"
 *           //del ".\main\recipes\cmr_hist"
 *
 *
 *            HKEY_CURRENT_USER\Software\Activision
 *            HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\DISPLAY\
 *            
 *            
 *            
 *            cd "C:\Program Files (x86)\Call of Duty Modern Warfare\main"

cd "C:\Program Files (x86)\Call of Duty Modern Warfare\Data\data"
del shmem

cd "C:\Program Files (x86)\Call of Duty Modern Warfare\main\recipes"
del cmr_hist

cd "C:\Users%USERPROFILE%\AppData\Roaming"
rd "Battle.net" /s /q

*/

