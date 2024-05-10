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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace clinic_system
{
    public partial class diagnose : Form
    {
        private string patientnumber;
        private string docnumber;
        private Patient patientInstance;
        private Diagnosis diagnosisInstance;
        private Medication investigationInstance;

        private MySqlConnection connection;



        public diagnose(string patientnumber, string docnumber)
        {
            InitializeComponent();
            this.patientnumber = patientnumber;
            this.docnumber = docnumber;
            Messages messages = new Messages("", "");
            patientInstance = new Patient(messages);
            diagnosisInstance = new Diagnosis(messages);
            connection = db.Instance.GetConnection();
            investigationInstance = new Medication(messages);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void diagnose_Load(object sender, EventArgs e)
        {
            patientInstance.load_patient_details(patientnumber, dataGridView1);

        }
        public void loaddata()
        {
            //TreatmentFactory factory = new TreatmentFactory();
            //Treatment treatment = factory.CreateTreatment("bone");
            //string diagnosis = treatment.GetDiagnosis();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            diagnosis_miniform miniForm = new diagnosis_miniform(patientnumber, docnumber);
            this.Hide();
            miniForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            patient_search p = new patient_search(patientnumber);
            p.Show();
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == display.Columns["description"].Index)
            {
                // Get the value of the "description" cell
                string description = display.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                // Open the mini-form to display the description
                showdescription miniForm = new showdescription(description);

                miniForm.ShowDialog();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            PatientReport patientReport = new PatientReport(patientnumber, docnumber);

            patientReport.Show();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    MySqlConnection connection = db.Instance.GetConnection();
        //    connection.Open();
        //    treatment miniForm = new treatment(patientnumber, docnumber);

        //    miniForm.Show();
        //    this.Hide();
        //}

        private void button7_Click(object sender, EventArgs e)
        {


            diagnosisInstance.display_diagnosis(patientnumber, display);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            diagnosisInstance.display_treatment(patientnumber, display);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            add_medication miniForm = new add_medication(patientnumber, docnumber);
            this.Hide();
            miniForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            investigationInstance.display_investigation(patientnumber, display);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MySqlConnection connection = db.Instance.GetConnection();
            connection.Open();
            investigation miniForm = new investigation(patientnumber, docnumber);

            miniForm.Show();
            this.Hide();
        }
    }
}
