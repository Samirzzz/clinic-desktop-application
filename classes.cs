using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_system
{
    internal class classes
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
            db d = new db();
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
            public bool setnumber(string number)
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
                    this.number = number;
                    return true;
                }
            }

            }
        public class Doctor
        {
            public int did;
            public string drname;
            public int drnumber;
            public string spec;

        }
    }
}
