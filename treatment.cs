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
using static clinic_system.diagnose;


namespace clinic_system
{
    public partial class treatment : Form
    {
        private MySqlConnection connection;
        private string patientnumber;
        private string docnumber;
        private List<string> selectedTreatments = new List<string>();
        public treatment(string patientnumber, string docnumber)
        {
            InitializeComponent();
            this.patientnumber = patientnumber;
            this.docnumber = docnumber;
            connection = db.Instance.GetConnection();

        }

        private void Diagnosis_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            Treatment treatment = null;
            string selectedDiagnosis = comboBox1.SelectedItem?.ToString();
            if (selectedDiagnosis == "Bone")
            {
                treatment = new BoneTreatment();
            }
            else if (selectedDiagnosis == "Cancer")
            {
                treatment = new cancerTreatment();
            }

            if (treatment != null)
            {

                CheckBox rb1 = new CheckBox();
                CheckBox rb2 = new CheckBox();

                rb1.Width = 200;
                rb2.Width = 200;
                treatment.treatment(rb1, rb2);
                rb1.Location = new Point(10, 10);
                panel1.Controls.Add(rb1);

                rb2.Location = new Point(10, 50);
                panel1.Controls.Add(rb2);
            }


        }
        private void treatment_Load(object sender, EventArgs e)
        {
            //MySqlConnection connection = db.Instance.GetConnection();
            //connection.Open();

            comboBox1.Items.Clear();


            List<string> diagnoses = new List<string>
               {
                "Bone",
                "Cancer",
            };
            foreach (string diagnosis in diagnoses)
            {
                comboBox1.Items.Add(diagnosis);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            selectedTreatments.Clear();
            foreach (Control control in panel1.Controls)
            {
                if (control is CheckBox && ((CheckBox)control).Checked)
                {
                    selectedTreatments.Add(((CheckBox)control).Text);
                }
            }
            MySqlConnection connection = db.Instance.GetConnection();
            SaveToDatabase(selectedTreatments, connection);
        }

        void SaveToDatabase(List<string> treatments, MySqlConnection connection)
        {
            try
            {
                string treatmentDescription = string.Join(", ", treatments);
                string query = "INSERT INTO treatment (dnumber, pnumber, description) VALUES (@dnumber, @pnumber, @description)";
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, connection))
                {
                    mySqlCommand.Parameters.AddWithValue("@dnumber", docnumber);
                    mySqlCommand.Parameters.AddWithValue("@pnumber", patientnumber);
                    mySqlCommand.Parameters.AddWithValue("@description", treatmentDescription);
                    mySqlCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Treatments saved successfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void customsave_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = db.Instance.GetConnection();
            savecustom(connection);
        }

        private void customtreatment_TextChanged(object sender, EventArgs e)
        {

        }
        void savecustom(MySqlConnection connection)
        {
            try
            {


                string query = "INSERT INTO treatment (pnumber, dnumber, description) VALUES (@pnumber, @dnumber, @description)";
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, connection))
                {
                    string description = customtreatment.Text;
                    mySqlCommand.Parameters.AddWithValue("@pnumber", patientnumber);
                    mySqlCommand.Parameters.AddWithValue("@dnumber", docnumber);
                    mySqlCommand.Parameters.AddWithValue("@description", description);
                    int rowsAffected = mySqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Added successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add.");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            this.Hide();
            diagnose d = new diagnose(patientnumber,docnumber);
            d.ShowDialog();
            
            this.Close();
        }
    }
}
    

