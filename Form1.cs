using System.IO;
using Microsoft.Win32;
using WK.Libraries.HotkeyListenerNS;
using StartupHelper;
namespace DeltaType
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Hotkey hotkey1 = new Hotkey(Keys.Control, Keys.D);
        public static StartupManager StartupController =
            new StartupManager("Delta Type", RegistrationScope.Local);
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!StartupController.IsRegistered)
            {
                StartupController.Register();
            }
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            var hkl = new HotkeyListener();
            hkl.Add(hotkey1);
            hkl.HotkeyPressed += Hkl_HotkeyPressed;
            notifyIcon1.BalloonTipTitle = "Welcome to Δ Type!";
            notifyIcon1.BalloonTipText = "Press Control + D to begin";
            notifyIcon1.Icon = Icon;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(30000);
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
            if (StartupController.IsRegistered)
            {
                StartupController.Unregister();
                MessageBox.Show("Warning: Program will be readded to startup next launch, you can disable startup permanently in task manager");
            }
        }
    }
}
