using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WK.Libraries.BootMeUpNS;
using WK.Libraries.HotkeyListenerNS;


namespace DeltaType
{
    public partial class Form3 : Form
    {
        public Form1 f1;
        public BootMeUp bootMeUp1;
        public Hotkey hotkey2;
        public Form3(Form1 f, Hotkey hk)
        {
            this.f1 = f;
            this.hotkey2 = hk;
            InitializeComponent();
        }
        public bool started = false;
        internal static HotkeySelector hotkeySelector = new HotkeySelector();
        private void Form3_Load(object sender, EventArgs e)
        {            
            checkBox1.Checked = Properties.Settings.Default.Startup;
            update_radiobuttons();
            started = true;
            hotkeySelector.Enable(textBox2, hotkey2);
        }
        public void update_radiobuttons()
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Character Sets");
            DirectoryInfo d = new DirectoryInfo(fileName); //Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.csv"); //Getting Text files
            var buttons = new[] { new { Id = "", Name = "" } }.ToList(); //this is stupid and only here cause i dont know how lists work
            buttons.Clear();
            foreach(FileInfo file in Files)
            {
                buttons.Add(new { Id = file.FullName, Name = Path.GetFileNameWithoutExtension(file.FullName)});
            }
            radioListButton1.DisplayMember = "Name";
            radioListButton1.ValueMember = "Id";
            radioListButton1.DataSource = buttons;
            if (Files.Length < 1)
            {
                MessageBox.Show("Please create a preset!");
            }
            else
            {
                radioListButton1.SelectedIndex = radioListButton1.FindString(Properties.Settings.Default.File);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.Startup = true;
                Properties.Settings.Default.Save();
                bootMeUp1.Register();

            }
            else if (checkBox1.Checked == false)
            {
                Properties.Settings.Default.Startup = false;
                Properties.Settings.Default.Save();
                bootMeUp1.Unregister();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength > 0)
            {
                var filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Character Sets");
                string templatepath = Path.Combine(filepath, "csv.tpl");
                string filename = textBox1.Text + ".csv";
                filepath = Path.Combine(filepath, filename);
                if (File.Exists(filepath) == false)
                {
                    File.Copy(templatepath, filepath, false);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("File already exists! \nOverride?", "Δ Type Error Handling Subsystem", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Copy(templatepath, filepath, true);
                    }
                }
                update_radiobuttons();
            }
            else
            {
                MessageBox.Show("Please enter file name");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", radioListButton1.SelectedValue.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will permanently delete this file \nAre you sure?", "Δ Type Notification Handling Subsystem", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                File.Delete(radioListButton1.SelectedValue.ToString());
                update_radiobuttons();
            }
        }
        
        private void radioListButton1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (started)
            {
                Properties.Settings.Default.FilePath = radioListButton1.SelectedValue.ToString();
                Properties.Settings.Default.File = radioListButton1.GetItemText(radioListButton1.SelectedItem);
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.hkl.Update
            (
                // Reference the current clipping hotkey for directly updating 
                // the hotkey without a need for restarting your application.
                ref Form1.hotkey1,

                // Convert the selected hotkey's text representation 
                // to a Hotkey object and update it.
                HotkeyListener.Convert(Properties.Settings.Default.Shortcut)
            );
            Properties.Settings.Default.Save();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Shortcut = textBox2.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Character Sets"));
        }
    }
}
