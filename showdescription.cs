using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_system
{
    public partial class showdescription : Form
    {
        public showdescription(string description)
        {
            InitializeComponent();
            DisplayDescription(description);

        }

        private void showdescription_Load(object sender, EventArgs e)
        {

        }
        private void DisplayDescription(string description)
        {
            richTextBox1.Text = description;

            richTextBox1.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular);
            richTextBox1.ForeColor = System.Drawing.Color.Black;
            richTextBox1.BackColor = System.Drawing.Color.White;
            richTextBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
    }
}
