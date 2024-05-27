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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace clinic_system
{
    public partial class viewAppointments : Form
    {
        DataTable dt = new DataTable();

        public viewAppointments()
        {
            InitializeComponent();
            db.Instance.GetConnection();
            // Set up the DataTable and add it to a container control
            dt.Columns.Add("Docnumber", typeof(string));
            dt.Columns.Add("Patnumber", typeof(string));
            dt.Columns.Add("Date", typeof(string));
            dataGridView1.DataSource = dt;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            appointbox.ReadOnly = true;
            Appointment.viewAppointments(dt);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Populate the text boxes with data from the selected row
                dnumBox.Text = row.Cells["Docnumber"].Value.ToString();
                PnumBox.Text = row.Cells["Patnumber"].Value.ToString();
                Datebox.Text = row.Cells["Date"].Value.ToString();
                appointbox.Text = row.Cells["Appid"].Value.ToString();
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            int AppointId = int.Parse(appointbox.Text);

            if (Appointment.deleteAppointment(AppointId, dt))
            {
                Datebox.Text = "";
                dnumBox.Text = "";
                PnumBox.Text = "";
                appointbox.Text = "";
                MessageBox.Show("Appointment deleted successfully.");
            }
            else
            {
                MessageBox.Show("Failed to delete appointment.");
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to save.");
                return;
            }

            string patnumber = PnumBox.Text;
            int AppointId = int.Parse(appointbox.Text);



            try
            {
                Appointment appointment = new Appointment();
                appointment.updateAppointment(patnumber, AppointId, dt);
                MessageBox.Show("Edit has been saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void appointbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
