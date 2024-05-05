using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using static clinic_system.classes;

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
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.Columns["number"].ReadOnly = true;
            numbox.ReadOnly = true;
            dataGridView1.CellClick += dataGridView1_CellClick;
            Patient.viewPatients(dt);
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

                Patient p = new Patient();
                p.editPatient(newName, patientNumber, dt);
                MessageBox.Show("Edit has been saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
                return;
            }
            string patientNumber = numbox.Text;
            Patient p = new Patient();
            if (p.DeletePatient(patientNumber, dt))
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

        private void numbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
