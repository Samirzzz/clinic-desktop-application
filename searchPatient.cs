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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using static clinic_system.classes;

namespace clinic_system
{
    public partial class searchPatient : Form
    {
        private Clinic clinicinstance = new Clinic();
        private MySqlConnection connection;
        public searchPatient()
        {
            InitializeComponent();
            connection = db.Instance.GetConnection();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            string entered_number = Number_textbox.Text.ToString();
            viewpatientdetails view=new viewpatientdetails(entered_number);
            view.Show();
            this.Hide();


        }

        private void Name_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void searchPatient_Load(object sender, EventArgs e)
        {

        }
    }
}
