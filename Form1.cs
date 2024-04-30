using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace clinic_system
{
    public partial class Form1 : Form
    {
        public class db
        {
           public string mysqlconn = "server=localhost; user=root; database=clinic-system; password=";
           public MySqlConnection mysqlconnection;
            public void connection()
            {
                string mysqlconn = "server=localhost; user=root; database=clinic-system; password=";
                mysqlconnection = new MySqlConnection(mysqlconn);
                try
                {
                    mysqlconnection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                

            }

            public void ExecuteNonQuery(string query)
            {
                MySqlCommand mySqlCommand = new MySqlCommand(query, mysqlconnection);
                mySqlCommand.ExecuteNonQuery();
            }
        }
        public class Patient
        {
            public int pid;
            public string name;
            public string number;
            db d = new db();
          

        }
        public class Doctor
        {
            public int did;
            public string drname;
            public int drnumber;
            public string spec;

        }
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
