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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            db.Instance.GetConnection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginDoctor f = new loginDoctor();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginClinic f = new LoginClinic();
            f.Show();
            this.Hide();
        }
    }
}
