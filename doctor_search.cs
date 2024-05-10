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
using static clinic_system.classes;

namespace clinic_system
{
    public partial class doctor_search : Form
    {

        private Doctor doctorInstance;
        private MySqlConnection connection;

        public doctor_search()
        {
            InitializeComponent();

            Messages messages = new Messages("", "");
            doctorInstance = new Doctor(messages);
            connection = db.Instance.GetConnection();

        }

        private void enterbut_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = db.Instance.GetConnection();

            string number = doctor_num.Text.ToString();
            doctorInstance.doctor_search(number, this, connection);


        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void doctor_search_Load(object sender, EventArgs e)
        {

        }

        private void doctor_num_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
           

            this.Close();
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
