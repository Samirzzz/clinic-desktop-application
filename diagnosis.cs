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
    public partial class diagnosis : Form
    {
        private string patientnumber;
        private string docnumber;

        public diagnosis(string patientnumber,string docnumber)
        {
            InitializeComponent();
            this.patientnumber = patientnumber;
            this.docnumber = docnumber;
        }

        private void patient_name_Click(object sender, EventArgs e)
        {
            patient_name.Text= patientnumber;
            doc_name.Text= docnumber;
            TreatmentFactory factory = new TreatmentFactory();
            Treatment treatment = factory.createTreatment("bone");
            string diagnosis = treatment.getdiagnosis();
            diag.Text=diagnosis;
        }
    }
}
