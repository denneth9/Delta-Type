using System;
using System.IO;
using System.Windows;
namespace DeltaType
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public class delta //delta class to store both character and description
        {

            public string name;
            public string character;
            //todo: expand to support multiple descriptions
            public delta(string name, string character)
            {
                this.name = name;
                this.character = character;
            }
        }
        public List<delta> characters = new List<delta>();
        public List<delta> filtered = new List<delta>();

        private void Form2_Load(object sender, EventArgs e)
        {
            Activate();
            int height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height);
            int width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width);
            int mousex = MousePosition.X;
            int mousey = MousePosition.Y;
            int locx = mousex;
            int locy = mousey;
            if(mousex >= width / 2) //check which quadrant of the primary screen the mouse is on, and place the window accordingly
            {
                locx = mousex - Size.Width;
            }
            else if (mousex < width / 2)
            {
                locx = mousex;
            }
            if (mousey >= height / 2)
            {
                locy = mousey - Size.Height;
            }
            else if (mousey < height / 2)
            {
                locy = mousey;
            }
            Location = new Point(locx, locy);
            this.StartPosition = FormStartPosition.Manual;
            try
            {
                using (var reader = new StreamReader(@"chars.csv")) //read local .csv file
                {
                    List<string> listA = new List<string>();
                    List<string> listB = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (line.Substring(0, 1) != "#") //ignore lines beginning with #
                        {
                            var values = line.Split(',');
                            values[1] = values[1].Trim();
                            characters.Add(new delta(values[0], values[1])); //insert values into delta list
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error reading from .csv file, please check formatting", "Δ Type has encountered an error!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            this.Deactivate += new System.EventHandler(this.Form2_Deactivate);
            characters.Sort((a, b) => a.character.CompareTo(b.character));
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.HorizontalScroll.Maximum = 0; //disables horizontal scroll bar
            flowLayoutPanel1.AutoScroll = false;
            flowLayoutPanel1.VerticalScroll.Visible = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.AutoScroll = true;
            update_flowpanel(characters);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtered = new List<delta>();
            string filter = textBox1.Text;
            if (filter == string.Empty)
            {
                filtered = characters;
            }
            else
            {
                foreach (var character in characters)
                {
                    if (character.name.ToUpperInvariant().StartsWith(filter.ToUpperInvariant()))
                    {
                        filtered.Add(character);
                    }
                }
            }
            update_flowpanel(filtered);
        }

        public void update_flowpanel(List<delta> buttons)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                foreach (var character in buttons)
                {
                    Button button = new Button();
                    //button.Tag = character.name; //removed cause i dont even know what tags are for, that and performance
                    button.Text = character.character;
                    this.toolTip1.SetToolTip(button, character.name);
                    switch (character.character.Length) //switch statement instead of if for slight performance gains
                    {
                        case 1:
                            button.Size = new Size(30, 30);
                            break;
                        default:
                            button.AutoSize = true;
                            button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                            break;

                    }
                    if (character.character.Length == 1)
                    {
                    }
                    else
                    {

                    }
                    button.Click += new EventHandler(this.button1_Click);
                    flowLayoutPanel1.Controls.Add(button);
                }
            }
            catch
            {
                MessageBox.Show("Error updating selection menu", "Δ Type has encountered an error!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            //no idea where this came from, or how to remove it
        }
        private void Form2_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
        void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Button button = sender as Button;
            if (button == null)
                return;
            SendKeys.Send(button.Text);
            Close();
        }
        bool shifted;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((ModifierKeys & Keys.Shift) != 0 && shifted == false)
            {
                List<delta> uppercase = new List<delta>();
                string filter = "upper";
                if (textBox1.Text.Length == 0)
                {
                    foreach (var character in characters)
                    {
                        if (character.name.ToUpperInvariant().Contains(filter.ToUpperInvariant()))
                        {
                            uppercase.Add(character);
                        }
                    }
                }
                else
                {
                    foreach (var character in filtered)
                    {
                        if (character.name.ToUpperInvariant().Contains(filter.ToUpperInvariant()))
                        {
                            uppercase.Add(character);
                        }
                    }
                }
                update_flowpanel(uppercase);
                shifted = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                var controls = flowLayoutPanel1.Controls.OfType<Button>();
                if (controls.Count() >= 1)
                {
                    Button button = controls.First();
                    button.PerformClick();
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((ModifierKeys & Keys.Shift) == 0 && shifted == true)
            {
                shifted = false;
                if (textBox1.Text.Length == 0)
                {
                    update_flowpanel(characters);
                }
                else
                {
                    update_flowpanel(filtered);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if the link is clicked, open denneth.nl in the default browser and display it as visited
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("explorer", "https://denneth.nl");
        }
    }
}