using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using clinic_system;
using static clinic_system.classes;
namespace clinic_system
{
    public partial class viewDoctors : Form
    {
        DataTable dt = new DataTable();

        public viewDoctors()
        {
            InitializeComponent();
            // Set up the DataTable and add it to a container control
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("number", typeof(string)); // Primary key
            dt.Columns.Add("spec", typeof(string));
            dataGridView1.DataSource = dt;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.Columns["number"].ReadOnly = true;
            numbox.ReadOnly = true;
            Doctor.viewDoctors(dt);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to save.");
                return;
            }

            string doctorNumber = numbox.Text; // Changed from did to number
            string newName = namebox.Text;
            string newSpec = specbox.Text;

            try
            {
                Doctor doc = new Doctor();
                doc.updateDoctor(newName, doctorNumber, newSpec);
                    DataRow[] rows = dt.Select("number = '" + doctorNumber + "'");
                if (rows.Length > 0)
                {
                    rows[0]["name"] = newName;
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

        

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Populate the text boxes with data from the selected row
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

            string doctorNumber = numbox.Text;

            Doctor doc = new Doctor();
           
            if (doc.deleteDoctor(doctorNumber, dt))
            {
                namebox.Text = "";
                numbox.Text = "";
                specbox.Text = "";
                MessageBox.Show("Doctor deleted successfully.");
            }
            else
            {
                MessageBox.Show("Failed to delete doctor.");
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
