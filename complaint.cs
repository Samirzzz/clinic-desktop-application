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
    public partial class complaint : Form
    {
        private Patient patientInstance;
        private MySqlConnection connection;

        private string patientnumber;
        private string docnumber;

        public complaint(string patnumber, string docnumber)
        {
            InitializeComponent();
            Messages messages = new Messages("", "");
            patientInstance = new Patient(messages);
            connection = db.Instance.GetConnection();
            this.patientnumber = patnumber;
            this.docnumber = docnumber;

        }

        private void save_Click(object sender, EventArgs e)
        {
            string comp = textBox1.Text.ToString();
            patientInstance.addcheifcompliant(patientnumber, comp, connection);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            diagnose p = new diagnose(patientnumber, docnumber);
            p.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void complaint_Load(object sender, EventArgs e)
        {
             patientInstance.displaycheifcomplaint(patientnumber,textBox1, connection);
        }
    }
}
