using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
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
    public partial class patient_registration : Form
    {

        private Patient patientInstance;
         private  Clinic clinicInstance;
        private MySqlConnection connection;
        public patient_registration()
        {
            InitializeComponent();
            
            Messages messages = new Messages("", "");
            clinicInstance=new Clinic(messages);
            patientInstance = new Patient(messages);
            connection = db.Instance.GetConnection();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string name = patient_name.Text.ToString();
            string number = patient_number.Text.ToString();
            
            patientInstance.setname(name);
            if (patientInstance.validatenumber(number))
            {
                clinicInstance.addpatient(name, number,connection);

            }




        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            db.Instance.CloseConnection();
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
