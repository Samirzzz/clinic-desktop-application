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
                int xOffset = 10;
                int yOffset = 10;
                int xStep = 210;  
                int yStep = 40;   
                int checkboxesPerRow = 5;
                Font smallerFont = new Font("Arial", 8);
                CheckBox[] checkBoxes = new CheckBox[38];

                for (int i = 0; i < 38; i++)
                {
                    int x = xOffset + (i % checkboxesPerRow) * xStep;
                    int y = yOffset + (i / checkboxesPerRow) * yStep;
                    checkBoxes[i] = new CheckBox { Width = 200, Location = new Point(x, y), Font = smallerFont };
                    panel1.Controls.Add(checkBoxes[i]);
                }
               
                treatment.treatment(checkBoxes[0], checkBoxes[1], checkBoxes[2], checkBoxes[3], checkBoxes[4],
                                           checkBoxes[5], checkBoxes[6], checkBoxes[7], checkBoxes[8], checkBoxes[9],
                                           checkBoxes[10], checkBoxes[11], checkBoxes[12], checkBoxes[13], checkBoxes[14],
                                           checkBoxes[15], checkBoxes[16], checkBoxes[17], checkBoxes[18], checkBoxes[19],
                                           checkBoxes[20], checkBoxes[21], checkBoxes[22], checkBoxes[23], checkBoxes[24],
                                           checkBoxes[25], checkBoxes[26], checkBoxes[27], checkBoxes[28], checkBoxes[29],
                                           checkBoxes[30], checkBoxes[31], checkBoxes[32], checkBoxes[33], checkBoxes[34],
                                           checkBoxes[35], checkBoxes[36], checkBoxes[37]);
                if (selectedDiagnosis == "Singles")
                {
                    checkBoxes[37].Width = 400;
                }
                if (selectedDiagnosis != "Singles")
                {
                    for (int i = 25; i < checkBoxes.Length; i++)
                    {
                        checkBoxes[i].Hide();
                    }
                }



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
    

