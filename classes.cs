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
            public void setnumber(string number)
            {

                if (number.Length < 11)
                {
                    messages.message = "Number must be bigger than 11 characters";
                    messages.title = "Validation error";
                    messages.show_messages();
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
