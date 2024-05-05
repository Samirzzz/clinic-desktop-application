using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace clinic_system
{
    public partial class viewPatients : Form
    {
        DataTable dt = new DataTable();

        public viewPatients()
        {
            InitializeComponent();
            // Set up the DataTable and add it to a container control
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("number", typeof(string)); // Primary key
            dataGridView1.DataSource = dt;
            // Attach CellClick event handler
            dataGridView1.CellClick += dataGridView1_CellClick;

            // Make the number field read-only
            dataGridView1.Columns["number"].ReadOnly = true;
            numbox.ReadOnly = true;
            LoadPatients();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to save.");
                return;
            }

            string patientNumber = numbox.Text; // Changed from pid to number
            string newName = namebox.Text;

            try
            {
                // Query to update the patient record
                string query = "UPDATE patient SET name = @name WHERE number = @number";

                // Create and execute the command with parameters
                using (MySqlCommand cmd = new MySqlCommand(query, classes.db.Instance.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", newName);
                    cmd.Parameters.AddWithValue("@number", patientNumber);
                    cmd.ExecuteNonQuery();
                }

                // Update the DataTable with the new values
                DataRow[] rows = dt.Select("number = '" + patientNumber + "'");
                if (rows.Length > 0)
                {
                    rows[0]["name"] = newName;
                }

                // Display success message
                MessageBox.Show("Edit has been saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadPatients()
        {
            try
            {
                // Query to select all patients
                string query = "SELECT * FROM patient";

                // Execute the query and get the result
                dt.Clear(); // Clear the DataTable before filling with new data
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, classes.db.Instance.GetConnection()))
                {
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool DeletePatient(string patientNumber)
        {
            try
            {
                string query = "DELETE FROM patient WHERE number = @number";

                // Create and execute the command with parameters
                using (MySqlCommand cmd = new MySqlCommand(query, classes.db.Instance.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@number", patientNumber);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Remove the row from the DataTable
                        DataRow[] rows = dt.Select("number = '" + patientNumber + "'");
                        if (rows.Length > 0)
                        {
                            dt.Rows.Remove(rows[0]);
                        }
                    }

                    return rowsAffected > 0; // Return true if rows were affected (deletion successful)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false; // Return false if an exception occurred
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Populate the text boxes with data from the selected row
                namebox.Text = row.Cells["name"].Value.ToString();
                numbox.Text = row.Cells["number"].Value.ToString();
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            // Check if there is a selected row in the DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return; // Exit the method
            }

            // Get the Number of the selected patient from the Number text box
            string patientNumber = numbox.Text;

            // Delete the patient record from the database
            bool deleteSuccessful = DeletePatient(patientNumber);

            // Display message based on delete result
            if (deleteSuccessful)
            {
                namebox.Text = "";
                numbox.Text = "";
                MessageBox.Show("Patient deleted successfully.");
            }
            else
            {
                MessageBox.Show("Failed to delete patient.");
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void viewPatients_Load(object sender, EventArgs e)
        {
            
        }
    }
}
