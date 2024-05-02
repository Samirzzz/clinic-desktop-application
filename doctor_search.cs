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
    public partial class doctor_search : Form
    {
        private db dbInstance;
        private Doctor doctorInstance;
        public doctor_search()
        {
            InitializeComponent();
            dbInstance = new db();

            Messages messages = new Messages("", "");
            doctorInstance = new Doctor(messages);
        }

        private void enterbut_Click(object sender, EventArgs e)
        {
          
                string number = doctor_num.Text.ToString();
                doctorInstance.doctor_search(number);
            
          
        }
    }
}
