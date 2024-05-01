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
            Messages messages = new Messages("", "");
            patientInstance = new Patient(messages);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                dbInstance.connection();
                string name = patient_name.Text.ToString();
                string number = patient_number.Text.ToString();
                patientInstance.setname(name);
                if (patientInstance.setnumber(number))
                {
                    string query = "INSERT INTO patient (name, number) VALUES (@name, @number)";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, dbInstance.mysqlconnection);
                    mySqlCommand.Parameters.AddWithValue("@name", patientInstance.getname());
                    mySqlCommand.Parameters.AddWithValue("@number", patientInstance.getnumber());
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
                
                
            }
            catch(Exception ex) 
            {
                MessageBox.Show("error: "+ex.Message);
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
