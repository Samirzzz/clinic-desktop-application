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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace clinic_system
{
    public partial class appointmentBooking : Form
    {
        DataTable dt = new DataTable();

        private Appointment appointment;
        private MySqlConnection connection;
        private Doctor doctorInstance;



        public appointmentBooking()
        {
            InitializeComponent();
            Messages messages = new Messages();
            appointment = new Appointment(messages);
            connection = db.Instance.GetConnection();
            dt.Columns.Add("name", typeof(string));
            Doctor.viewDoctors(dt);
            foreach (DataRow row in dt.Rows)
            {
                string doctorName = row["name"].ToString();
                comboBox1.Items.Add(doctorName);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedDoctor = comboBox1.SelectedItem.ToString();
            string doctorNumber = null;

            string query = "SELECT number FROM doctor WHERE name = @name";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@name", selectedDoctor);
                doctorNumber = cmd.ExecuteScalar()?.ToString();
            }

            if (!string.IsNullOrEmpty(doctorNumber))
            {
                MessageBox.Show($"Doctor Number: {doctorNumber}");
            }
            else
            {
                MessageBox.Show("Doctor not found.");
            }

            appointment.bookAppointment(doctorNumber, textBox1.Text, datee.Value, connection);

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
