using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace clinic_system
{
    public partial class viewPatients : Form
    {
        private classes.db db = new classes.db();
        DataTable dt = new DataTable();
        public viewPatients()
        {
            InitializeComponent();
            // Fetch and display patient records when the form loads

            // Set up the DataTable and add it to a container control
            dt.Columns.Add("pid", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("number", typeof(string));
            dataGridView1.DataSource = dt;


            LoadPatients();
            // Set up the DataTable and add it to a container control



        }
        private void editbtn_Click(object sender, EventArgs e)
        {
            // Your logic for editing a patient here
            MessageBox.Show("Edit button clicked");
        }

        // Define the event handler for the delete button click
        private void deletebtn_Click(object sender, EventArgs e)
        {
            // Your logic for deleting a patient here
            MessageBox.Show("Delete button clicked");
        }
        private void LoadPatients()
        {
            try
            {
                // Establish database connection
                db.connection();

                // Query to select all patients
                string query = "SELECT pid, name, number FROM patient";

                // Execute the query and get the result
                dt.Clear(); // Clear the DataTable before filling with new data
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.mysqlconnection))
                {
                    adapter.Fill(dt);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is the edit button
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                // Handle edit button click (You can open a new form for editing here)
                MessageBox.Show("Edit button clicked for patient ID: " + dataGridView1.Rows[e.RowIndex].Cells["pid"].Value.ToString());
            }
            // Check if the clicked cell is the delete button
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                // Handle delete button click
                int patientId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["pid"].Value);
                DeletePatient(patientId);
            }
        }

        private void DeletePatient(int patientId)
        {
            try
            {
                // Establish database connection
                db.connection();

                // Query to delete the patient
                string query = "DELETE FROM patients WHERE pid = @pid";

                // Create and execute the command with parameters
                using (MySqlCommand cmd = new MySqlCommand(query, db.mysqlconnection))
                {
                    cmd.Parameters.AddWithValue("@pid", patientId);
                    cmd.ExecuteNonQuery();
                }

                // Refresh the DataGridView after deletion
                LoadPatients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void viewPatients_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
