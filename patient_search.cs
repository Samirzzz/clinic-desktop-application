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
    public partial class patient_search : Form
    {
        private MySqlConnection connection;

        private Patient patientInstance;
        private Clinic ClinicInstance=new Clinic();
        private string docnumber;
        private string patientnumber;
       

        public patient_search(string docnumber)
        {
            InitializeComponent();
            this.docnumber = docnumber;
            this.patientnumber = docnumber;
            connection = db.Instance.GetConnection();
            Messages messages = new Messages("", "");
            patientInstance = new Patient(messages);
        }

        private void enterbut_Click(object sender, EventArgs e)
        {
            string number = patient_num.Text.ToString();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            ClinicInstance.patient_search(number, docnumber, this, connection);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }



        private void patient_search_Load(object sender, EventArgs e)
        {
            //MySqlConnection connection = db.Instance.GetConnection();
            //connection.Open();
        }

        private void patient_num_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
          Form1 f = new Form1();
            f.Show();   

            this.Hide();
          

            //this.Close();
        }
    }
}
