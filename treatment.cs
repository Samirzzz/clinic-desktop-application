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
    public partial class treatment : Form
    {
        private string patientnumber;
        private string docnumber;
        public treatment(string patientnumber, string docnumber)
        {
            InitializeComponent();
            this.patientnumber = patientnumber;
            this.docnumber = docnumber;
        }

        private void Diagnosis_Click(object sender, EventArgs e)
        {
            label1.Text = patientnumber;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            Treatment treatment = null;
            string selectedDiagnosis = comboBox1.SelectedItem?.ToString();
            if (selectedDiagnosis == "Bone")
            {
                treatment = new BoneTreatment();
            }
            else if (selectedDiagnosis == "Cancer")
            {
                treatment = new cancerTreatment();
            }

            if (treatment != null)
            {

                CheckBox rb1 = new CheckBox();
                CheckBox rb2 = new CheckBox();

                rb1.Width = 200;
                rb2.Width = 200;
                treatment.treatment(rb1, rb2);
                rb1.Location = new Point(10, 10);
                panel1.Controls.Add(rb1);

                rb2.Location = new Point(10, 50);
                panel1.Controls.Add(rb2);
            }


        }
        private void treatment_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();


            List<string> diagnoses = new List<string>
               {
                "Bone",
                "Cancer",
            };
            foreach (string diagnosis in diagnoses)
            {
                comboBox1.Items.Add(diagnosis);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {

        }
    }
}
