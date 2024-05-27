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
    public partial class viewpatientdetails : Form
    {
        private Patient PatientInstance;
        private Clinic ClinicInstance=new Clinic();
        private MySqlConnection connection;
        public viewpatientdetails(string  patient)
        {
            InitializeComponent();
           PatientInstance = ClinicInstance.FindByPatientNumber(patient,connection);
            patient_num.Text=PatientInstance.getname();
            textBox1.Text = patient;
        }

        private void patient_num_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
