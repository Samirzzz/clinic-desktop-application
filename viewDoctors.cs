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
        private Appointment appointment = new Appointment();
        private MySqlConnection connection;

        public viewDoctors()
        {
            InitializeComponent();
            try
            {
                connection = db.Instance.GetConnection();
                // Set up the DataTable and add it to a container control
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("number", typeof(string));
                dt.Columns.Add("spec", typeof(string));
                dt.Columns.Add("doctor workdays", typeof(string));
                dataGridView1.DataSource = dt;
                dataGridView1.CellClick += dataGridView1_CellClick;
                dataGridView1.Columns["number"].ReadOnly = true;
                numbox.ReadOnly = true;
                Doctor.viewDoctors(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing form: " + ex.Message);
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to save.");
                return;
            }

            string doctorNumber = numbox.Text;
            string newName = namebox.Text;
            string newSpec = specbox.Text;
            List<string> Workdays = new List<string>();

            foreach (var item in checkedListBox1.CheckedItems)
            {
                Workdays.Add(item.ToString());
            }

            try
            {
                Doctor doc = new Doctor();
                doc.updateDoctor(newName, doctorNumber, newSpec, dt);
                doc.updateDoctorWorkingDays(doctorNumber, Workdays, connection);
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

                if (row.Cells["name"].Value != null)
                    namebox.Text = row.Cells["name"].Value.ToString();
                else
                    namebox.Text = string.Empty;

                if (row.Cells["number"].Value != null)
                    numbox.Text = row.Cells["number"].Value.ToString();
                else
                    numbox.Text = string.Empty;

                if (row.Cells["spec"].Value != null)
                    specbox.Text = row.Cells["spec"].Value.ToString();
                else
                    specbox.Text = string.Empty;
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

            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting doctor: " + ex.Message);
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            db.Instance.CloseConnection();
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void viewDoctors_Load(object sender, EventArgs e)
        {

        }

        private void speclbl_Click(object sender, EventArgs e)
        {

        }
    }
}
