using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_system
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;
        public Form1()
        {
            InitializeComponent();
            Instance = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            patient_registration Patient_reg_form = new patient_registration();
            Patient_reg_form.Show();
            this.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void AddDoctor_Click(object sender, EventArgs e)
        {
            doctor_registration doctor_reg_form = new doctor_registration();
            doctor_reg_form.Show();
            this.Hide();
        }

        private void searchPatient_Click(object sender, EventArgs e)
        {
            searchPatient view_patient = new searchPatient();
            view_patient.Show();
            this.Hide();
        }

        private void SearchDoctor_Click(object sender, EventArgs e)
        {
            doctor_search doctor_search_= new doctor_search();
            doctor_search_.Show();
            this.Hide();
         }
    }
}
