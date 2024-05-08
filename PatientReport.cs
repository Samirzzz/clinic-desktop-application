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
        public List<int> diagnoses_ids= new List<int>();
        private Patient patientInstance = new Patient();
        Patient found_patient = new Patient();
        private Diagnosis diagnosesInstance=new Diagnosis();
       
        public string curr_number { get; set; }






        public PatientReport()
        {
            InitializeComponent();
            db.Instance.GetConnection();

        }

        private void PatientReport_Load(object sender, EventArgs e)
        { 
            int counter = 0;
            using (MySqlConnection conn = db.Instance.GetConnection())
            {
                conn.Open();

                // Call functions with the same database connection
             found_patient = patientInstance.FindByPatientNumber(curr_number,conn);
                Name_textbox.Text = found_patient.getname();
                textBox1.Text = found_patient.getnumber();

                diagnoses_ids.Clear();
                diagnoses_ids = diagnosesInstance.GetDiagnosesIDs(found_patient.getnumber());
               
                while (diagnoses_ids.Count > 0)
                {
                    comboBox1.Items.Add(diagnoses_ids[counter]);
                    counter++;
                }


                textBox5.Text = diagnosesInstance.FindDescription(1, found_patient.getnumber(),conn);
            }
            //Patient curr_patient = patientInstance.findbypatientnumber(curr_number);
            //Name_textbox.Text = curr_patient.getname();
            //textBox1.Text = curr_patient.getnumber();
            
            //diagnoses_ids.Clear();  
            //diagnoses_ids=diagnosesInstance.GetDiagnosesIDs(curr_patient.getnumber());
            //int counter = 0;
            //while( diagnoses_ids.Count > 0 )
            //{
            //    comboBox1.Items.Add(diagnoses_ids[counter] );
            //    counter++;
            //}


            //textBox5.Text=diagnosesInstance.FindDescription(1, curr_patient.getnumber());

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
            db.Instance.CloseConnection();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {


        }
    }
}
