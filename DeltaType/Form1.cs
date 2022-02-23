using System.IO;
using Microsoft.Win32;
using System.Reflection;
using WK.Libraries.HotkeyListenerNS;
namespace DeltaType
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        internal static HotkeyListener hkl = new HotkeyListener();
        internal static Hotkey hotkey1 = new Hotkey(Keys.Control, Keys.D);
        private void Form1_Load(object sender, EventArgs e)
        {
            if (HotkeyListener.Convert(Properties.Settings.Default.Shortcut).ToString() == "None")
            {
                Properties.Settings.Default.Shortcut = hotkey1.ToString();
            }
            hkl.Update(ref hotkey1, HotkeyListener.Convert(Properties.Settings.Default.Shortcut));
            if (bootMeUp1.Enabled == false && Properties.Settings.Default.Startup == true) 
            {
                bootMeUp1.Register();
            } //this could be better / removed
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Character Sets");
            DirectoryInfo d = new DirectoryInfo(fileName); //Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.csv"); //Getting Text files
            if (Files.Length > 0)
            {
                if (Properties.Settings.Default.FilePath == string.Empty)
                {
                    Properties.Settings.Default.FilePath = Files[0].FullName;
                }
            }
            else
            {
                MessageBox.Show("Please make a preset!");
            }
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
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
        {//currently deimplemented while presets are made
            if (MessageBox.Show("This will reset the character configuration to the factory defaults and restart Δ Type \nare you sure you want to continue?", "Δ Type factory reset", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                File.Copy(@"chars.csv.bu", @"chars.csv", true);
                Application.Restart();
                Environment.Exit(0);
            }
        }

        private void closeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editCharacterDefenitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", "chars.csv");
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3(this, hotkey1);
            hkl.SuspendOn(frm);
            frm.bootMeUp1 = bootMeUp1;
            frm.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
