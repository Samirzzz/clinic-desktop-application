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

        public appointmentBooking()
        {
            InitializeComponent();
            db.Instance.GetConnection();
            // Set up the DataTable and add it to a container control
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
    }
}
