using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static clinic_system.classes;
using static clinic_system.doctor_search;
using static clinic_system.patient_search;


namespace clinic_system
{
    internal class classes
    {
        public class db
        {
            private static db instance;
            private string mysqlconn = "server=localhost; user=root; database=clinic-system; password=";
            private MySqlConnection mysqlconnection;

            private db()
            {
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

            public static db Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new db();
                    }
                    return instance;
                }
            }

            public void ExecuteNonQuery(string query)
            {
                MySqlCommand mySqlCommand = new MySqlCommand(query, mysqlconnection);
                mySqlCommand.ExecuteNonQuery();
            }
            public MySqlConnection GetConnection()
            {
                return mysqlconnection;
            }
        }
        public class Messages
        {
            public string message;
            public string title;


            public Messages(string message,string title)
            {
                this.message = message;
                this.title=title;
            }
            public void show_messages()
            {
                MessageBox.Show(message, title);
            }
        }
        public class Patient
        {
            
            public int pid;
            public string name;
            public string number;
            Messages messages;
            public Patient(Messages messages)
            {
                this.messages = messages;
            }
            public string getname()
            {
                return this.name;
            }
            public string getnumber()
            {
                return this.number;
            }
            public void setname(string name)
            {
                this.name = name;
            }
            public void setnumber(string number)
            {
                this.number = number;
            }
            public bool validatenumber(string number)
            {

                if (string.IsNullOrEmpty(number))
                {
                    messages.message = "No empty field is allowed";
                    messages.title = "Validation error";
                    messages.show_messages();
                    return false;
                }
                else if (number.Length < 11)
                {
                    messages.message = "Number must be at least 11 characters long";
                    messages.title = "Validation error";
                    messages.show_messages();
                    return false ;
                }
                else
                {
                    setnumber(number);
                    return true;
                }
            }
            public void addpatient(string name,string number)
            {
                try
                {

 
                    string query = "INSERT INTO patient (name, number) VALUES (@name, @number)";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, db.Instance.GetConnection());
                    mySqlCommand.Parameters.AddWithValue("@name", name);
                    mySqlCommand.Parameters.AddWithValue("@number", number);
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
                catch (Exception ex)
                {
                    MessageBox.Show("error: " + ex.Message);
                }


            }
             public void patient_search(string number)
            {
                try
                {
                    db dbInstance = new db();

                    dbInstance.connection();



                    string query = "SELECT number FROM patient WHERE number = @number";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, dbInstance.mysqlconnection);
                    mySqlCommand.Parameters.AddWithValue("@number", number);


                    using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MessageBox.Show($"Doctor with number {number} is found.");



                        }
                        else
                        {
                            MessageBox.Show($"Doctor with number {number} not found.");
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("error: " + ex.Message);
                }
            }
        }
        public class Doctor
        {
            public int did;
            public string name;
            public string number;
            public string spec;
            Messages messages;
            public Doctor(Messages messages)
            {
                this.messages = messages;
            }
            public string getname()
            {
                return this.name;
            }
            public string getnumber()
            {
                return this.number;
            }
            public string getspec()
            {
                return this.spec;
            }
            public void setspec(string spec)
            {
                this.spec = spec;
            }
            public void setname(string name)
            {
                this.name = name;
            }
            public void setnumber(string number)
            {
                this.number= number;    
            }

            public bool validatenumber(string number)
            {

                if (string.IsNullOrEmpty(number))
                {
                    messages.message = "No empty field is allowed";
                    messages.title = "Validation error";
                    messages.show_messages();
                    return false;
                }
                else if (number.Length < 11)
                {
                    messages.message = "Number must be at least 11 characters long";
                    messages.title = "Validation error";
                    messages.show_messages();
                    return false;
                }
                else
                {
                    setnumber(number);
                    return true;
                }
            }
            public void adddoctor(string name,string number,string spec)
            {
                try
                {
       


                    string query = "INSERT INTO doctor (name, number,spec) VALUES (@name, @number, @spec)";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, db.Instance.GetConnection());
                    mySqlCommand.Parameters.AddWithValue("@name", name);
                        mySqlCommand.Parameters.AddWithValue("@number",number);
                        mySqlCommand.Parameters.AddWithValue("@spec", spec);

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
                catch (Exception ex)
                {
                    MessageBox.Show("error: " + ex.Message);
                }
            }
            public void doctor_search(string number,Form hide)
            {
                try
                {




                    string query = "SELECT number FROM doctor WHERE number = @number";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, db.Instance.GetConnection());
                    mySqlCommand.Parameters.AddWithValue("@number", number);


                    using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            patient_search patientform = new patient_search();
                            patientform.Show();
                            hide.Hide();
                           
                        }
                        else
                        {
                            MessageBox.Show($"Doctor with number {number} not found.");
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("error: " + ex.Message);
                }
            }
    }
        public class Diagnosis
        {
            int diagid;
            int did;
            int pid;
            string description;
            public int getdiagid()
            {
                return this.diagid;
            }
            public void setspec(int diagid)
            {
                this.diagid = diagid;
            }
            public int getdid()
            {
                return this.did;
            }
            public void setdid(int did)
            {
                this.did = did;
            }
            public int getpid()
            {
                return this.pid;
            }
            public void setpid(int pid)
            {
                this.pid = pid;
            }
            public string getdescription()
            {
                return this.description;
            }
            public void setdescription(string description)
            {
                this.description = description;
            }

           


        }
    }
}
