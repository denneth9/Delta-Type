using System.IO;
using Microsoft.Win32;
using WK.Libraries.HotkeyListenerNS;
//using StartupHelper;
namespace DeltaType
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Hotkey hotkey1 = new Hotkey(Keys.Control, Keys.D);
        private void Form1_Load(object sender, EventArgs e)
        {
            if (bootMeUp1.Enabled == false && Properties.Settings.Default.Startup == true) 
            {
                bootMeUp1.Register();
            } //this could be better / removed
            if (bootMeUp1.Enabled == true)
            {
                (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDownItems[0].Text = "Disable Startup";
            }
            else
            {
                (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDownItems[0].Text = "Enable Startup";
            }
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            var hkl = new HotkeyListener();
            hkl.Add(hotkey1);
            hkl.HotkeyPressed += Hkl_HotkeyPressed;
            notifyIcon1.BalloonTipTitle = "Welcome to Δ Type!";
            notifyIcon1.BalloonTipText = "Press Control + D to begin";
            notifyIcon1.Icon = Icon;
            notifyIcon1.Visible = true;
            string[] args = Environment.GetCommandLineArgs();
            var result = Array.Find(args, element => element == "silent"); // returns "Bill" //might not be true
            if (result == null) //dont display the balloooon if it started automagically
            {
                notifyIcon1.ShowBalloonTip(30000);
            }
            Hide();

        }
        private void Hkl_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (e.Hotkey == hotkey1)
            {
                Form2 frm = new Form2();
                frm.Show();
            }
        }

        private void resetToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void closeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeFromStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(bootMeUp1.Enabled && Properties.Settings.Default.Startup == true)
            {
                (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDownItems[0].Text = "Enable Startup";
                Properties.Settings.Default.Startup = false;
                Properties.Settings.Default.Save();
                bootMeUp1.Unregister();
            }
            else if(bootMeUp1.Enabled == false && Properties.Settings.Default.Startup == false)
            {
                (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDownItems[0].Text = "Disable Startup";
                Properties.Settings.Default.Startup = true;
                Properties.Settings.Default.Save();
                bootMeUp1.Register();
            }
        }
    }
}
