using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using static clinic_system.classes;

namespace clinic_system
{
    public partial class Form1 : Form
    {
       
        private db dbInstance;
        private Patient patientInstance;
        public Form1()
        {
            InitializeComponent();
            dbInstance = new db();
            patientInstance = new Patient();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dbInstance.connection();
            patientInstance.name = patient_name.Text.ToString();
            patientInstance.number = patient_number.Text.ToString();
            string query = "INSERT INTO patient (name, number) VALUES (@name, @number)";
            MySqlCommand mySqlCommand = new MySqlCommand(query, dbInstance.mysqlconnection);
            mySqlCommand.Parameters.AddWithValue("@name", patientInstance.name);
            mySqlCommand.Parameters.AddWithValue("@number", patientInstance.number);
            int rowsAffected = mySqlCommand.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("User added successfully!");
            }
            else
            {
                MessageBox.Show("Failed to add user.");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
