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
    public partial class investigation : Form
    {
        // Dictionary to store selected checkboxes
        private Dictionary<string, List<string>> selectedCheckboxes = new Dictionary<string, List<string>>();
        private List<string> selectedTreatments = new List<string>();

        private MySqlConnection connection;
        private string patientnumber;
        private string docnumber;
        public investigation(string patientnumber, string docnumber)
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
            string selectedDiagnosis = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedDiagnosis)) return;

            // Save current selections
            SaveCurrentSelections();

            panel1.Controls.Clear();
            Investigation treatment = null;

            if (selectedDiagnosis == "MicroBiology")
            {
                treatment = new microbiologyinvestigation();
            }
            else if (selectedDiagnosis == "ChemoTherapy")
            {
                treatment = new Chemotherapyinvestigation();
            }
            else if (selectedDiagnosis == "Singles")
            {
                treatment = new singlesinvestigation();
            }

            if (treatment != null)
            {
                CheckBox rb1 = new CheckBox { Width = 200, Location = new Point(10, 10) };
                CheckBox rb2 = new CheckBox { Width = 200, Location = new Point(10, 50) };
                treatment.treatment(rb1, rb2);

                panel1.Controls.Add(rb1);
                panel1.Controls.Add(rb2);

                LoadSavedSelections(selectedDiagnosis);
            }
        }

        private void SaveCurrentSelections()
        {
            string selectedDiagnosis = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedDiagnosis)) return;

            List<string> selections = new List<string>();
            foreach (CheckBox checkbox in panel1.Controls.OfType<CheckBox>())
            {
                if (checkbox.Checked)
                {
                    selections.Add(checkbox.Text);
                }
            }
            selectedCheckboxes[selectedDiagnosis] = selections;
        }

        private void LoadSavedSelections(string diagnosis)
        {
            if (selectedCheckboxes.ContainsKey(diagnosis))
            {
                List<string> selections = selectedCheckboxes[diagnosis];
                foreach (CheckBox checkbox in panel1.Controls.OfType<CheckBox>())
                {
                    if (selections.Contains(checkbox.Text))
                    {
                        checkbox.Checked = true;
                    }
                }
            }
        }

        private void treatment_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            List<string> diagnoses = new List<string> { "Singles", "ChemoTherapy", "MicroBiology" };
            foreach (string diagnosis in diagnoses)
            {
                comboBox1.Items.Add(diagnosis);
            }
        }
     
        private void save_Click(object sender, EventArgs e)
        {
            SaveCurrentSelections();

            // Combine all selections from all investigation types
            List<string> allSelections = new List<string>();
            foreach (var selections in selectedCheckboxes.Values)
            {
                allSelections.AddRange(selections);
            }

            // Ensure the selectedTreatments list is populated
            selectedTreatments = allSelections;
            MySqlConnection connection = db.Instance.GetConnection();
            SaveToDatabase(selectedTreatments, connection);
        }

        void SaveToDatabase(List<string> treatments, MySqlConnection connection)
        {
            try
            {
                string treatmentDescription = string.Join(", ", treatments);
                string query = "INSERT INTO investigation (dnumber, pnumber, description) VALUES (@dnumber, @pnumber, @description)";
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, connection))
                {
                    mySqlCommand.Parameters.AddWithValue("@dnumber", docnumber);
                    mySqlCommand.Parameters.AddWithValue("@pnumber", patientnumber);
                    mySqlCommand.Parameters.AddWithValue("@description", treatmentDescription);
                    mySqlCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Investigation saved successfully!");

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


                string query = "INSERT INTO investigation (pnumber, dnumber, description) VALUES (@pnumber, @dnumber, @description)";
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
    

