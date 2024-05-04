using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace clinic_system
{
    public partial class viewDoctors : Form
    {

        DataTable dt = new DataTable();
        public viewDoctors()
        {
            InitializeComponent();


            // Set up the DataTable and add it to a container control
            dt.Columns.Add("did", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("number", typeof(string));
            dt.Columns.Add("spec", typeof(string));
            dataGridView1.DataSource = dt;

            dataGridView1.CellClick += dataGridView1_CellClick;

            idbox.ReadOnly = true;
            LoadDoctors();




        }


        private void savebtn_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to save.");
                return;
            }


            int doctorId = Convert.ToInt32(idbox.Text);
            string newName = namebox.Text;
            string newNumber = numbox.Text;
            string newSpec = specbox.Text;

            try
            {



                string query = "UPDATE doctor SET name = @name, number = @number , spec = @spec WHERE did = @did";


                using (MySqlCommand cmd = new MySqlCommand(query, classes.db.Instance.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", newName);
                    cmd.Parameters.AddWithValue("@number", newNumber);
                    cmd.Parameters.AddWithValue("@did", doctorId);
                    cmd.Parameters.AddWithValue("@spec", newSpec);
                    cmd.ExecuteNonQuery();
                }

                // Update the DataTable with the new values
                DataRow[] rows = dt.Select("did = " + doctorId);
                if (rows.Length > 0)
                {
                    rows[0]["name"] = newName;
                    rows[0]["number"] = newNumber;
                    rows[0]["spec"] = newSpec;
                }

                // Display success message
                MessageBox.Show("Edit has been saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }






        private void LoadDoctors()
        {
            try
            {




                string query = "SELECT * FROM doctor";


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



        private bool DeleteDoctor(int doctorId)
        {
            try
            {



                string query = "DELETE FROM doctor WHERE did = @did";


                using (MySqlCommand cmd = new MySqlCommand(query, classes.db.Instance.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@did", doctorId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Remove the row from the DataTable
                        DataRow[] rows = dt.Select("did = " + doctorId);
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
                return false;
            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Populate the text boxes with data from the selected row
                idbox.Text = row.Cells["did"].Value.ToString();
                namebox.Text = row.Cells["name"].Value.ToString();
                numbox.Text = row.Cells["number"].Value.ToString();
                specbox.Text = row.Cells["spec"].Value.ToString();
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


            int doctorId = Convert.ToInt32(idbox.Text);


            bool deleteSuccessful = DeleteDoctor(doctorId);


            if (deleteSuccessful)
            {
                idbox.Text = "";
                namebox.Text = "";
                numbox.Text = "";
                specbox.Text = "";
                MessageBox.Show("doctor deleted successfully.");
            }
            else
            {
                MessageBox.Show("Failed to delete doctor.");
            }
        }

        private void viewDoctors_Load(object sender, EventArgs e)
        {

        }

        private void speclbl_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void namelbl_Click(object sender, EventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
