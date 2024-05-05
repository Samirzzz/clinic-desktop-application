using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace clinic_system
{
    public partial class loginDoctor : Form
    {
        public loginDoctor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = txtnumber.Text;
            string password = txtpassword.Text;
            if (number == "123" && password == "123")
            {
                Form1 f = new Form1();
                f.Show();
            }
            else
            {
                MessageBox.Show("password or email is incorrect");
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            txtnumber.Text = "";
            txtpassword.Text = "";
        }
    }
}
