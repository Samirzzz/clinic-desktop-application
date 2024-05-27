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

namespace clinic_system
{
    public partial class Form1 : Form
    {
        public static Form1 Instancee;
        public Form1()
        {
            InitializeComponent();
            db.Instance.GetConnection();
            Instancee = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = db.Instance.GetConnection();
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                patient_registration Patient_reg_form = new patient_registration();
                Patient_reg_form.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void AddDoctor_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = db.Instance.GetConnection();
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                doctor_registration doctor_reg_form = new doctor_registration();
                doctor_reg_form.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void searchPatient_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = db.Instance.GetConnection();
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                patient_search view_patient = new patient_search("1");
                view_patient.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void SearchDoctor_Click(object sender, EventArgs e)
        {

            MySqlConnection connection = db.Instance.GetConnection();
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                doctor_search doctor_search_ = new doctor_search();
                doctor_search_.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void rudpatientbtn_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = db.Instance.GetConnection();
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                viewPatients viewp = new viewPatients();
                viewp.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void doctorRUD_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = db.Instance.GetConnection();
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                viewDoctors vd = new viewDoctors();
                vd.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void WelcomeText_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlConnection connection = db.Instance.GetConnection();
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                appointmentBooking viewp = new appointmentBooking();
                viewp.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = db.Instance.GetConnection();
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                viewAppointments viewp = new viewAppointments();
                viewp.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           

            Home p = new Home();
                p.Show();
                this.Close();
            
        }
    }
}
