using System;
using System.Windows.Forms;
using System.Linq;
using Spoof;
using System.Diagnostics;
using System.Drawing;

namespace modestGieikCleaner
{
    public partial class AppForm : Form
    {
        private SpooferFns spoofFns;

        public AppForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            spoofFns = new SpooferFns(this);
            AppendText("Modest GIEIK Cleaner\n");
            AppendText("This is a free software, if you payed for it you got scammed.\n", Color.Red);
            AppendText("SAVE YOUR SERIALS, DATA, PROGRAMS BEFORE EXECUTING!\nTHIS IS PERMANENT, THERE IS NO TURNING BACK.\nPrepare yourself for the worst scenario\n", Color.Red);
            AppendText("Waiting for user choice...");
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            optionsPanel.Enabled = false;
            RadioButton activeRadio = optionsPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            string task = activeRadio.Name;
            Process[] agentProcesses = Process.GetProcessesByName("Agent");
            Process[] bnetProcesses = Process.GetProcessesByName("Battle.net");
            Process[] processes = agentProcesses.Union(bnetProcesses).ToArray();
            foreach (var process in processes)
            {
                process.Kill();
            }
            AppendText($"Starting task: {activeRadio.Text}");

            if (task == RadioBoxTracers.Name)
            {
                spoofFns.CleanTracers();
            }
            else if (task == RadioBoxHKeys.Name)
            {
                spoofFns.CleanHKeys();
            }
            else if (task == RadioBoxBIOS.Name)
            {
                spoofFns.SpoofBIOS();
            }
            else if (task == RadioBoxMAC.Name)
            {
                spoofFns.SpoofMAC();
            }
            else if (task == RadioBoxHDD.Name)
            {
                spoofFns.SpoofVolumesID();
            }
            else if (task == RadioBoxCleanAll.Name)
            {
                spoofFns.CleanTracers();
                spoofFns.CleanHKeys();
                spoofFns.SpoofBIOS();
                spoofFns.SpoofMAC();
                spoofFns.SpoofVolumesID();
            }
            AppendText("DONE, NOW REBOOT YOUR PC", Color.Lime);
            optionsPanel.Enabled = true;
        }

        public void AppendText(string str, Color? color = null)
        {
            fakeConsole.SelectionStart = fakeConsole.TextLength;
            fakeConsole.SelectionLength = 0;
            fakeConsole.SelectionColor = color ?? Color.White;
            fakeConsole.AppendText(Environment.NewLine + str);
        }

    }
}
