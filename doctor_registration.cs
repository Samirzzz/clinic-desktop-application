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
    public partial class doctor_registration : Form
    {

        private Doctor doctorInstance;
        public doctor_registration()
        {
            InitializeComponent();
            db.Instance.GetConnection();
            Messages messages = new Messages("", "");
            doctorInstance = new Doctor(messages);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = doctor_name.Text.ToString();
            string number = doctor_number.Text.ToString();
            string spec = doctor_spec.Text.ToString();
            doctorInstance.setname(name);
            doctorInstance.setspec(spec);

            List<string> selectedWorkdays = new List<string>();

            foreach (var item in checkedListBox1.CheckedItems)
            {
                selectedWorkdays.Add(item.ToString());
            }


            if (doctorInstance.validatenumber(number))
            {
                doctorInstance.adddoctor(name, number, spec, selectedWorkdays);
            }
        }


        private void doctor_registration_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.Instance.CloseConnection();

        }

        private void doctor_spec_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    viewDoctors form = new Form1();
        //    form.Show();
        //    this.Hide();
        //}
    }
}
