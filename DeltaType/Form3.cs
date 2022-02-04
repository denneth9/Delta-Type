using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeltaType
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        //ToDo: allow editing of .csv file inside of the program
        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                using (var reader = new StreamReader(@"chars.csv")) //read local .csv file
                {
                    List<string> listA = new List<string>();
                    List<string> listB = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        //values[1] = values[1].Trim();
                        //todo, parse the csv file into the ui
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error reading from .csv file, please check formatting", "Δ Type has encountered an error!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
