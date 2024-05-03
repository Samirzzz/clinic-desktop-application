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
    public partial class patient_search : Form
    {
        
        private Patient patientInstance;

        public patient_search()
        {
            InitializeComponent();
           

            Messages messages = new Messages("", "");
            patientInstance = new Patient(messages);
        }

        private void enterbut_Click(object sender, EventArgs e)
        {
            string number = patient_num.Text.ToString();
            patientInstance.patient_search(number);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
