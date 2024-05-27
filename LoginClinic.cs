using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static clinic_system.classes;

namespace clinic_system
{
    public partial class LoginClinic : Form
    {
        public LoginClinic()
        {
            InitializeComponent();
            db.Instance.GetConnection();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (username == "clinic_2024" && password == "1234")
            {
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("password or username is incorrect");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Home form = new Home();
            form.Show();
            this.Hide();
        }
    }
}
