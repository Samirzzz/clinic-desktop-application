﻿using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static clinic_system.classes;
using static clinic_system.doctor_search;
using static clinic_system.patient_search;
using static clinic_system.diagnose;
using System.Data;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;



namespace clinic_system
{
    internal class classes
    {
        public class db
        {
            private static db instance;
            private string mysqlconn = "server=localhost; user=root; database=clinic-system; password=; pooling=true;";
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
            public void CloseConnection()
            {
                if (mysqlconnection != null && mysqlconnection.State == ConnectionState.Open)
                {
                    mysqlconnection.Close();
                }
            }
        }
        public class Messages
        {
            public string message;
            public string title;


            public Messages(string message, string title)
            {
                this.message = message;
                this.title = title;
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
            Doctor doc = new Doctor();
            public Patient(Messages messages)
            {
                this.messages = messages;
            }
            public Patient() { }
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
                    return false;
                }
                else
                {
                    setnumber(number);
                    return true;
                }
            }
            public void addpatient(string name, string number)
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
            public void patient_search(string number, string docnumber, Form hide)
            {
                try
                {
                    string query = "SELECT number FROM patient WHERE number = @number";
                    using (MySqlCommand mySqlCommand = new MySqlCommand(query, db.Instance.GetConnection()))
                    {
                        mySqlCommand.Parameters.AddWithValue("@number", number);

                        using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                reader.Close();

                                patient_search doc = new patient_search(docnumber);
                                diagnose diagnosis = new diagnose(number, docnumber);
                                diagnosis.Show();
                                hide.Hide();
                            }
                            else
                            {
                                MessageBox.Show($"Doctor with number {number} not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }



            public void load_patient_details(string number, DataGridView d)
            {
                MySqlConnection connection = null;
                try
                {
                    string query = "SELECT * FROM patient WHERE number = @number";

                    DataTable dt = new DataTable();
                    connection = db.Instance.GetConnection();

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                    mySqlCommand.Parameters.AddWithValue("@number", number);

                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand))
                    {
                        mySqlDataAdapter.Fill(dt);
                    }

                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = dt;
                    d.DataSource = bindingSource;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            public void editPatient(string newName , string patientNumber , DataTable dt)
            {
                
                string query = "UPDATE patient SET name = @name WHERE number = @number";
                using (MySqlCommand cmd = new MySqlCommand(query, classes.db.Instance.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", newName);
                    cmd.Parameters.AddWithValue("@number", patientNumber);
                    cmd.ExecuteNonQuery();
                }

                // Update the DataTable with the new values
                DataRow[] rows = dt.Select("number = '" + patientNumber + "'");
                if (rows.Length > 0)
                {
                    rows[0]["name"] = newName;
                }
            }
            public static void viewPatients(DataTable dt)
            {
                try
                {

                    string query = "SELECT * FROM patient";


                    dt.Clear();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, classes.db.Instance.GetConnection()))
                    {
                        adapter.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            public bool DeletePatient(string patientNumber , DataTable dt)
            {
                try
                {
                    string query = "DELETE FROM patient WHERE number = @number";

                    // Create and execute the command with parameters
                    using (MySqlCommand cmd = new MySqlCommand(query, classes.db.Instance.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@number", patientNumber);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Remove the row from the DataTable
                            DataRow[] rows = dt.Select("number = '" + patientNumber + "'");
                            if (rows.Length > 0)
                            {
                                dt.Rows.Remove(rows[0]);
                            }
                        }

                        return rowsAffected > 0; // Return true if rows were affected (deletion successful)
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false; // Return false if an exception occurred
                }
            }

        }
        public class Doctor
        {
            public int did;
            public string name;
            public string number;
            public string spec;
            public string password;
            
            Messages messages;
            public Doctor()
            {

            }
            public Doctor(Messages messages)
            {
                this.messages = messages;
            }
            public string getname()
            {
                return this.name;
            }
            public string getpass()
            {
                return this.password;
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
            public void setpassword(string password)
            {
                this.password = password;
            }
            public bool IsValidCredentials(string number, string password)
            {
                try
                {
                    
                    string query = "SELECT COUNT(*) FROM doctor WHERE number = @number AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, classes.db.Instance.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@number", number);
                        cmd.Parameters.AddWithValue("@password", password);

                        
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if(count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
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
            public void adddoctor(string name, string number, string spec, List<string> workdays)
            {
                try
                {
                    string query = "INSERT INTO doctor (name, number, spec) VALUES (@name, @number, @spec)";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, db.Instance.GetConnection());
                    mySqlCommand.Parameters.AddWithValue("@name", name);
                    mySqlCommand.Parameters.AddWithValue("@number", number);
                    mySqlCommand.Parameters.AddWithValue("@spec", spec);

                    int rowsAffected = mySqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User added successfully!");

                        foreach (string workday in workdays)
                        {
                            query = "INSERT INTO doctor_workdays (did, Wid) SELECT doctor.number, workdays.Wid FROM doctor, workdays WHERE doctor.number = @number AND workdays.Day = @workday";
                            MySqlCommand workdayCommand = new MySqlCommand(query, db.Instance.GetConnection());
                            workdayCommand.Parameters.AddWithValue("@number", number);
                            workdayCommand.Parameters.AddWithValue("@workday", workday);

                            int workdayRowsAffected = workdayCommand.ExecuteNonQuery();

                            if (workdayRowsAffected <= 0)
                            {
                                MessageBox.Show("Failed to add workday for doctor.");
                            }
                        }
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

                    using (MySqlCommand mySqlCommand = new MySqlCommand(query, db.Instance.GetConnection()))
                    {
                        mySqlCommand.Parameters.AddWithValue("@number", number);

                        using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                patient_search patientform = new patient_search(number);
                                patientform.Show();
                                hide.Hide();


                            }
                            else
                            {
                                MessageBox.Show($"Doctor with number {number} not found.");
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("error: " + ex.Message);
                }
            }
            public void updateDoctor(string newName , string doctorNumber , string newSpec , DataTable dt)
            {
                string query = "UPDATE doctor SET name = @name, spec = @spec WHERE number = @number";

                // Create and execute the command with parameters
                using (MySqlCommand cmd = new MySqlCommand(query, classes.db.Instance.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", newName);
                    cmd.Parameters.AddWithValue("@number", doctorNumber);
                    cmd.Parameters.AddWithValue("@spec", newSpec);
                    cmd.ExecuteNonQuery();
                }
                DataRow[] rows = dt.Select("number = '" + doctorNumber + "'");
                if (rows.Length > 0)
                {
                    rows[0]["name"] = newName;
                    rows[0]["spec"] = newSpec;
                }
            }
            public static void viewDoctors(DataTable dt) {
                try
                {
                    
                    string query = "SELECT number, name, spec FROM doctor";
                    dt.Clear(); 
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, classes.db.Instance.GetConnection()))
                    {
                        adapter.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            public bool deleteDoctor(string doctorNumber , DataTable dt)
            {
                try
                {
                    string query = "DELETE FROM doctor WHERE number = @number";

                   
                    using (MySqlCommand cmd = new MySqlCommand(query, classes.db.Instance.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@number", doctorNumber);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Remove the row from the DataTable
                            DataRow[] rows = dt.Select("number = '" + doctorNumber + "'");
                            if (rows.Length > 0)
                            {
                                dt.Rows.Remove(rows[0]);
                            }
                        }

                        return rowsAffected > 0; // Return true if rows were affected (deletion successful)
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }
        public interface Treatment
        {
            string getdiagnosis();
        }
        public class BoneTreatment : Treatment
        {
            public string getdiagnosis()
            {
                return "Bone related diagnosis";
            }
        }
        public class TreatmentFactory
        {
             public Treatment createTreatment(string diagnosis)
            {
                switch (diagnosis.ToLower())
                {
                    case "bone":
                        return new BoneTreatment();
                    default:
                        throw new ArgumentException("Invalid diagnosis");
                }

            }

            public string setxray()
            {
                return "X-ray reserved"; 
            }


        }

        public class Diagnosis
        {
            int diagid;
            int did;
            int pid;
            string description;
           
            
            Messages messages;
            public Diagnosis(Messages messages)
            {
                this.messages = messages;
            }
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

            public void adddescription(string pnumber, string dnumber, string description)
            {
                try
                {
                    using (MySqlConnection connection = db.Instance.GetConnection())
                    {
                        string query = "INSERT INTO diagnosis (pnumber, dnumber, description) VALUES (@pnumber, @dnumber, @description)";
                        using (MySqlCommand mySqlCommand = new MySqlCommand(query, connection))
                        {
                            mySqlCommand.Parameters.AddWithValue("@pnumber", pnumber);
                            mySqlCommand.Parameters.AddWithValue("@dnumber", dnumber);
                            mySqlCommand.Parameters.AddWithValue("@description", description);
                            connection.Open();
                            int rowsAffected = mySqlCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Added successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Failed to add.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }


            }


        }
    }
    //public class Appointment
    //{
    //    public string docnumber;
    //    public string patnumber;
    //    public DateTime date;
    //    public string status;

    //    public void addAppointment(string docnumber,string patnumber,DateTime date,string status)
    //    {
    //        try
    //        {



    //            string query = "INSERT INTO appointment (docnumber, patnumber,date,status) VALUES (@docnumber, @patnumber, @date,@status)";
    //            MySqlCommand mySqlCommand = new MySqlCommand(query, db.Instance.GetConnection());
    //            mySqlCommand.Parameters.AddWithValue("@docnumber", docnumber);
    //            mySqlCommand.Parameters.AddWithValue("@patnumber", patnumber);
    //            mySqlCommand.Parameters.AddWithValue("@date", date);
    //            mySqlCommand.Parameters.AddWithValue("@status", status);


    //            int rowsAffected = mySqlCommand.ExecuteNonQuery();


    //            if (rowsAffected > 0)
    //            {
    //                MessageBox.Show("Appointment added successfully!");
    //            }
    //            else
    //            {
    //                MessageBox.Show("Failed to add appointment.");
    //            }



    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("error: " + ex.Message);
    //        }
    //    }
    //}
    public class Appointment
    {
        private static Dictionary<string, List<DateTime>> appointmentsByDoctorAndDate = new Dictionary<string, List<DateTime>>();
        private const int MaxAppointmentsPerDay = 4;

        public void AddAppointment(string doctorNumber, string patientNumber, DateTime date, string status)
        {
            // Check if the doctor works on the selected day
            if (!DoctorWorksOnDay(doctorNumber, date.DayOfWeek))
            {
                MessageBox.Show("Doctor does not work on this day.");
                return;
            }

            // Check if the doctor already has appointments for the selected day
            if (!appointmentsByDoctorAndDate.ContainsKey(doctorNumber))
            {
                appointmentsByDoctorAndDate[doctorNumber] = new List<DateTime>();
            }

            // Check if the maximum number of appointments per day is reached
            if (appointmentsByDoctorAndDate[doctorNumber].Count(appDate => appDate.Date == date.Date) >= MaxAppointmentsPerDay)
            {
                MessageBox.Show("Doctor already has the maximum number of appointments for this day.");
                return;
            }

            // Add the appointment for the selected doctor and date
            appointmentsByDoctorAndDate[doctorNumber].Add(date.Date);
            MessageBox.Show("Appointment added successfully!");
        }

        private bool DoctorWorksOnDay(string doctorNumber, DayOfWeek dayOfWeek)
        {
            // Implement your logic here to check if the doctor works on the selected day
            // For example, if doctor John only works on Wednesdays, Thursdays, and Saturdays:
            if (doctorNumber == "John")
            {
                return dayOfWeek == DayOfWeek.Wednesday || dayOfWeek == DayOfWeek.Thursday || dayOfWeek == DayOfWeek.Saturday;
            }
            // If the doctor works every day, return true
            return true;
        }
    }


}
