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
    public partial class add_medication : Form
    {
        private Medication investigationInstance;
        private MySqlConnection connection;

        private string patientnumber;
        private string docnumber;
        public add_medication(string patientnumber, string docnumber)
        {
            InitializeComponent();
            this.patientnumber = patientnumber;
            this.docnumber = docnumber;
            db.Instance.GetConnection();
            Messages messages = new Messages("", "");
            investigationInstance = new Medication(messages);
            connection = db.Instance.GetConnection();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            string desc = textBox1.Text.ToString();
            investigationInstance.setdescription(desc);
            investigationInstance.add_description(patientnumber, docnumber, desc, connection);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            this.Hide();
            diagnose d = new diagnose(patientnumber, docnumber);
            d.ShowDialog();

            this.Close();
        }
    }
}
