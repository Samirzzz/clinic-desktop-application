﻿using System;
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
        private string docnumber;

        public patient_search(string docnumber)
        {
            InitializeComponent();
            this.docnumber = docnumber;


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

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = docnumber;
        }
    }
}
