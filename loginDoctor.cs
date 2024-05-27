using MySql.Data.MySqlClient;
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
using static clinic_system.classes;

namespace clinic_system
{
    public partial class loginDoctor : Form
    {
        private string docnumber;
        private MySqlConnection connection;

        public loginDoctor(string docnumber)
        {
            InitializeComponent();
            connection = db.Instance.GetConnection();
            this.docnumber = docnumber;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = txtnumber.Text;
            string password = txtpassword.Text;
            Messages messages=new Messages();
            classes.Doctor doctor=new classes.Doctor(messages);
            if (doctor.IsValidCredentials(number,password))
            {
                patient_search f = new patient_search(number);
                f.Show();
                this.Hide();
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
