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
    public partial class diagnosis_miniform : Form
    {
        private Diagnosis diagnosisInstance;
        private MySqlConnection connection;

        private string patientnumber;
        private string docnumber;
        public diagnosis_miniform(string patientnumber, string docnumber)
        {
            InitializeComponent();
            db.Instance.GetConnection();
            this.patientnumber = patientnumber;
            this.docnumber = docnumber;
            Messages messages = new Messages("", "");
            diagnosisInstance = new Diagnosis(messages);
            connection = db.Instance.GetConnection();

        }

        private void save_Click(object sender, EventArgs e)

        {
            string desc = textBox1.Text.ToString();
            diagnosisInstance.setdescription(desc);
            diagnosisInstance.adddescription(patientnumber, docnumber, desc,connection);
        }

        private void button5_Click(object sender, EventArgs e)
        {

           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Diagnosis_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            this.Hide();
            diagnose d = new diagnose(patientnumber, docnumber);
            d.ShowDialog();

            this.Close();

        }
    }
}
