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
        public List<int> investigation_ids = new List<int>();
        public List<int> medication_ids = new List<int>();


        Patient found_patient = new Patient();
        private Patient patientInstance;
        private Doctor drInstance;
        private Clinic clinicInstance;

        private MySqlConnection connection;

        private Diagnosis diagnosesInstance = new Diagnosis();
        private Medication medicationInstance;


        private string patientnumber;
        private string docnumber;








        public PatientReport(string patientnumber, string docnumber)
        {
            InitializeComponent();
            this.patientnumber = patientnumber;
            this.docnumber = docnumber;
            Messages messages = new Messages();
            patientInstance = new Patient(messages);
            clinicInstance = new Clinic(messages);
            drInstance = new Doctor(messages);

            connection = db.Instance.GetConnection();
            medicationInstance = new Medication(messages);
        }


        private void PatientReport_Load(object sender, EventArgs e)
        {
            int counter = 0;
            patientInstance.displaycheifcomplaint(patientnumber, textBox2, connection);

            drInstance.getdocname(docnumber, connection, textBox4);
            found_patient = clinicInstance.FindByPatientNumber(patientnumber, connection);
            Name_textbox.Text = found_patient.getname();
            textBox1.Text = found_patient.getnumber();


            diagnoses_ids = diagnosesInstance.GetDiagnosesIDs(found_patient.getnumber(), connection);
            investigation_ids = diagnosesInstance.GetinvestigationIDs(found_patient.getnumber(), connection);
            medication_ids = medicationInstance.GetmedicationIDs(found_patient.getnumber(), connection);
            foreach (int id in diagnoses_ids)
            {
                Console.WriteLine(id);
            }

            comboBox1.Items.Add("choose");
            comboBox1.Items.AddRange(diagnoses_ids.Select(i => i.ToString()).ToArray());
            comboBox2.Items.Add("choose");
            comboBox2.Items.AddRange(investigation_ids.Select(i => i.ToString()).ToArray());
            comboBox3.Items.Add("choose");
            comboBox3.Items.AddRange(medication_ids.Select(i => i.ToString()).ToArray());
            comboBox4.Items.Add("choose");
            comboBox4.Items.AddRange(investigation_ids.Select(i => i.ToString()).ToArray());



        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                int selectedDiagnosisId = int.Parse(comboBox1.SelectedItem.ToString());
                textBox5.Text = diagnosesInstance.FindDescription(selectedDiagnosisId, found_patient.getnumber(), connection);
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
            //            db.Instance.Closeconnectionection();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {


        }

        private void Name_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            diagnose p = new diagnose(patientnumber, docnumber);
            this.Hide();

        }

        private void close_Click(object sender, EventArgs e)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > 0)
            {
                drInstance.getdocname(docnumber, connection, textBox4);
                found_patient = clinicInstance.FindByPatientNumber(patientnumber, connection);
                Name_textbox.Text = found_patient.getname();
                textBox1.Text = found_patient.getnumber();

                investigation_ids = diagnosesInstance.GetinvestigationIDs(found_patient.getnumber(), connection);
                int selectedDiagnosisId = int.Parse(comboBox2.SelectedItem.ToString());
                textBox3.Text = diagnosesInstance.Findtreatmentdecription(selectedDiagnosisId, found_patient.getnumber(), connection);


            }

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex > 0)
            {
                int selectedDiagnosisId = int.Parse(comboBox3.SelectedItem.ToString());
                textBox6.Text = medicationInstance.Findmedicationdecription(selectedDiagnosisId, found_patient.getnumber(), connection);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Patient Details:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
            e.Graphics.DrawString("Name:  ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(100, 120));
            e.Graphics.DrawString(Name_textbox.Text, new Font("Arial", 10), Brushes.Black, new PointF(145, 120));

            e.Graphics.DrawString("Patient Number:  ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(100, 140));
            e.Graphics.DrawString(textBox1.Text, new Font("Arial", 10), Brushes.Black, new PointF(205, 140));

            e.Graphics.DrawString("Chief Complaint:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(100, 180));
            e.Graphics.DrawString(textBox2.Text, new Font("Arial", 10), Brushes.Black, new RectangleF(100, 200, 500, 50));

            e.Graphics.DrawString("Diagnosis Description:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(100, 280));
            e.Graphics.DrawString(textBox5.Text, new Font("Arial", 10), Brushes.Black, new RectangleF(100, 300, 500, 50));
            string concatenatedText = textBox3.Text + ", " + textBox7.Text;

            e.Graphics.DrawString("Investigation:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(100, 380));
            e.Graphics.DrawString(concatenatedText, new Font("Arial", 10), Brushes.Black, new RectangleF(100, 400, 500, 50));

            e.Graphics.DrawString("Medications:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(100, 480));
            e.Graphics.DrawString(textBox6.Text, new Font("Arial", 10), Brushes.Black, new RectangleF(100, 500, 500, 50));


            e.Graphics.DrawString("Doctor Name: ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(100, 600));
            e.Graphics.DrawString(textBox4.Text, new Font("Arial", 10), Brushes.Black, new PointF(200, 600));
            DateTime currentDate = DateTime.Now;

            string formattedDateTime = currentDate.ToString("MM/dd/yyyy HH:mm");
            e.Graphics.DrawString("Print Date/Time: ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(100, 620));
            e.Graphics.DrawString(formattedDateTime, new Font("Arial", 10), Brushes.Black, new PointF(220, 620));
        }
        Bitmap b;
        private void print_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            b = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(b);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ClientSize = new Size(1000, 900);
            printPreviewDialog1.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex > 0)
            {
                int selectedDiagnosisId2 = int.Parse(comboBox4.SelectedItem.ToString());

                textBox7.Text = diagnosesInstance.Findtreatmentdecription(selectedDiagnosisId2, found_patient.getnumber(), connection);

            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
