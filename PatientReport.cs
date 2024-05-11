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
    public partial class PatientReport : Form
    {
        public List<int> diagnoses_ids = new List<int>();
        Patient found_patient = new Patient();
        private Patient patientInstance;

        private Diagnosis diagnosesInstance = new Diagnosis();
        private string patientnumber;
        private string docnumber;

        MySqlConnection conn = db.Instance.GetConnection();







        public PatientReport(string patientnumber, string docnumber)
        {
            InitializeComponent();
            this.patientnumber = patientnumber;
            this.docnumber = docnumber;
            Messages messages = new Messages("", "");
            patientInstance = new Patient(messages);
        }


        private void PatientReport_Load(object sender, EventArgs e)
        {
            int counter = 0;
            using (conn)
            {
                conn.Open();

                // Call functions with the same database connection
                found_patient = patientInstance.FindByPatientNumber(patientnumber, conn);
                Name_textbox.Text = found_patient.getname();
                textBox1.Text = found_patient.getnumber();


                diagnoses_ids = diagnosesInstance.GetDiagnosesIDs(found_patient.getnumber(), conn);

                foreach (int id in diagnoses_ids)
                {
                    Console.WriteLine(id);
                }
                comboBox1.Items.Add("1");
                textBox5.Text = diagnosesInstance.FindDescription(diagnoses_ids[1], found_patient.getnumber(), conn);
                comboBox1.Items.AddRange(diagnoses_ids.Select(i => i.ToString()).ToArray());

            }
               

        }
       void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.SelectedText);
            using (MySqlConnection newconn = db.Instance.GetConnection())

            {
                newconn.Open();
                textBox5.Text = diagnosesInstance.FindDescription(comboBox1.SelectedIndex, found_patient.getnumber(), conn);
            }
        }
        private void REPORT_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Report_label_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //            db.Instance.CloseConnection();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {


        }

        private void Name_textbox_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
