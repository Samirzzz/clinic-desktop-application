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
using static clinic_system.diagnose;
using static clinic_system.investigation;

using System.Data;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;



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


            public Patient()
            {

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


            public Patient FindByPatientNumber(string number, MySqlConnection conn)
            {
                Patient curr_patient = new Patient();
                string query = "SELECT number, name FROM patient WHERE number = @number";

                using (MySqlCommand mySqlCommand = new MySqlCommand(query, conn))
                {
                    mySqlCommand.Parameters.AddWithValue("@number", number);

                    using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader.GetString("name");
                            string patientNum = reader.GetString("number");

                            curr_patient.setname(name);
                            curr_patient.setnumber(number);
                        }
                        else
                        {
                            MessageBox.Show($"Patient with number {number} not found.");
                        }
                    }
                }

                return curr_patient;
            }




            public void patient_search(string number, string docnumber, Form hide, MySqlConnection connection)
            {
                try
                {
                    string query = "SELECT number FROM patient WHERE number = @number";

                    using (MySqlCommand mySqlCommand = new MySqlCommand(query, connection))
                    {
                        mySqlCommand.Parameters.AddWithValue("@number", number);

                        using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                reader.Close();

                                patient_search doc = new patient_search(docnumber);
                                diagnose diagnosis = new diagnose(number, docnumber);
                                investigation treat=new investigation(number, docnumber);
                                PatientReport rep = new PatientReport(number,docnumber);
                                diagnosis.Show();
                                hide.Hide();
                                connection.Close();

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
            public void editPatient(string newName, string patientNumber, DataTable dt)
            {

                string query = "UPDATE patient SET name = @name WHERE number = @number";
                using (MySqlCommand cmd = new MySqlCommand(query, classes.db.Instance.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", newName);
                    cmd.Parameters.AddWithValue("@number", patientNumber);
                    cmd.ExecuteNonQuery();
                }

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
            public bool DeletePatient(string patientNumber, DataTable dt)
            {
                try
                {
                    string query = "DELETE FROM patient WHERE number = @number";

                    using (MySqlCommand cmd = new MySqlCommand(query, classes.db.Instance.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@number", patientNumber);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            DataRow[] rows = dt.Select("number = '" + patientNumber + "'");
                            if (rows.Length > 0)
                            {
                                dt.Rows.Remove(rows[0]);
                            }
                        }

                        return rowsAffected > 0; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false; 
                }
            }
            public void addcheifcompliant(string pnumber, string complaint, MySqlConnection connection)
            {
                try
                {

                    string query = "UPDATE patient SET complaint = @complaint WHERE number = @pnumber";
                    using (MySqlCommand mySqlCommand = new MySqlCommand(query, connection))
                    {
                        mySqlCommand.Parameters.AddWithValue("@pnumber", pnumber);
                        mySqlCommand.Parameters.AddWithValue("@complaint", complaint);
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            public void displaycheifcomplaint(string pnumber,TextBox b, MySqlConnection connection)
            {
                string complaint = null;
                try
                {
                    string query = "SELECT complaint FROM patient WHERE number = @pnumber";
                    using (MySqlCommand mySqlCommand = new MySqlCommand(query, connection))
                    {
                        mySqlCommand.Parameters.AddWithValue("@pnumber", pnumber);
                        object result = mySqlCommand.ExecuteScalar();
                        if (result != null)
                        {
                            complaint = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                b.Text = complaint;
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
                this.number = number;
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

                        if (count > 0)
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
            public void adddoctor(string name, string number, string spec, List<string> workdays,MySqlConnection connection)
            {
                try
                {
                    string query = "INSERT INTO doctor (name, number, spec) VALUES (@name, @number, @spec)";
                    MySqlCommand mySqlCommand = new MySqlCommand(query,connection);
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
                            MySqlCommand workdayCommand = new MySqlCommand(query, connection);
                            workdayCommand.Parameters.AddWithValue("@number", number);
                            workdayCommand.Parameters.AddWithValue("@workday", workday);

                            int workdayRowsAffected = workdayCommand.ExecuteNonQuery();
                            connection.Close();
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

            public void doctor_search(string number, Form hide, MySqlConnection connection)
            {
                try
                {
                    string query = "SELECT number FROM doctor WHERE number = @number";
                    using (MySqlCommand mySqlCommand = new MySqlCommand(query, connection))
                       {
                        mySqlCommand.Parameters.AddWithValue("@number", number);

                        using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                patient_search patientform = new patient_search(number);
                                patientform.Show();
                                hide.Hide();
                                connection.Close();


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
            public void updateDoctor(string newName, string doctorNumber, string newSpec, DataTable dt)
            {
                string query = "UPDATE doctor SET name = @name, spec = @spec WHERE number = @number";
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
            public static void viewDoctors(DataTable dt)
            {
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
            public bool deleteDoctor(string doctorNumber, DataTable dt)
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
                            DataRow[] rows = dt.Select("number = '" + doctorNumber + "'");
                            if (rows.Length > 0)
                            {
                                dt.Rows.Remove(rows[0]);
                            }
                        }

                        return rowsAffected > 0; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
            public void getdocname(string docNumber, MySqlConnection connection,TextBox b)
            {
                string doctorName = "";
                try
                {

                    string query = "SELECT name FROM doctor WHERE number = @docNumber";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@docNumber", docNumber);
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            doctorName = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
             
               b.Text = doctorName;


            }
        }

        public interface Treatment
        {
            string getdiagnosis();
            void setdiagnosis(string diagnosis);
            void treatment(CheckBox rb1, CheckBox rb2);
           
        }
        public class BoneTreatment : Treatment
        {
           
            public string getdiagnosis()
            {
                return "Bone related diagnosis";
                
            }
           

            public void setdiagnosis(string diagnosis)
            {
                diagnosis = "Bone";
            }
            public void treatment(CheckBox rb1, CheckBox rb2)
            {

                rb1.Text = "X-ray";
                rb2.Text = "MRI";

            }
        }
        public class cancerTreatment : Treatment
        {
            public string getdiagnosis()
            {
                return "cancer related diagnosis";
            }
            public void setdiagnosis(string diagnosis)
            {
                diagnosis = "Cancer";
            }

            public void treatment(CheckBox rb1, CheckBox rb2)
            {

                rb1.Text = "Chemotherapy";
                rb2.Text = "Radiotherapy";

            }
           
        }

        public class Medication
        {
            int iid;
            int did;
            int pid;
            string description;

            public Medication() { }

            Messages messages;
            public Medication(Messages messages)
            {
                this.messages = messages;
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

            public void add_description(string pnumber, string dnumber, string description, MySqlConnection connection)
            {
                try
                {

                    string query = "INSERT INTO medication (pnumber, dnumber, description) VALUES (@pnumber, @dnumber, @description)";
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            public void display_investigation(string number, DataGridView d)
            {
                MySqlConnection connection = null;

                try
                {

                    string query = "SELECT mid as id,pnumber,description FROM medication WHERE pnumber = @number ORDER BY mid DESC";

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

            public List<int> GetmedicationIDs(string pnumber, MySqlConnection connection)
            {


                List<int> diagnosisIds = new List<int>();

                string query = "SELECT mid FROM medication WHERE pnumber = @pnumber";


                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@pnumber", pnumber);

                    try
                    {

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int diagnosisId = reader.GetInt32("mid");
                                diagnosisIds.Add(diagnosisId);
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {

                        Console.WriteLine("Error: " + ex.Message);
                    }

                }


                return diagnosisIds;



            }
            public string Findmedicationdecription(int Diagnoses_id, string Patient_Number, MySqlConnection conn)
            {
                string query = "SELECT description FROM medication WHERE mid = @Diagnoses_id AND pnumber = @Patient_Number";

                using (MySqlCommand mySqlCommand = new MySqlCommand(query, conn))
                {
                    mySqlCommand.Parameters.AddWithValue("@Diagnoses_id", Diagnoses_id);
                    mySqlCommand.Parameters.AddWithValue("@Patient_Number", Patient_Number);

                    string curr_description = null;

                    using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            curr_description = reader.GetString("description");
                        }
                        else
                        {
                            MessageBox.Show($"Diagnosis with ID {Diagnoses_id} not found.");
                        }
                    }

                    return curr_description;
                }
            }


        }






            public class Diagnosis
        {
            int diagid;
            int did;
            int pid;
            string description;

            public Diagnosis() { }

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

            public void display_diagnosis(string number, DataGridView d)
            {

                MySqlConnection connection = null;

                try
                {
                    
                        string query = "SELECT diagid as id,pnumber,description FROM diagnosis WHERE pnumber = @number ORDER BY diagid DESC";

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


            public void display_treatment(string number, DataGridView d)
            {

                MySqlConnection connection = null;

                try
                {

                    string query = "SELECT tid as id,pnumber,description FROM treatment WHERE pnumber = @number ORDER BY tid DESC";

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

            public List<int> GetinvestigationIDs(string pnumber, MySqlConnection connection)
            {


                List<int> diagnosisIds = new List<int>();

                string query = "SELECT tid FROM treatment WHERE pnumber = @pnumber";


                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@pnumber", pnumber);

                    try
                    {

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int diagnosisId = reader.GetInt32("tid");
                                diagnosisIds.Add(diagnosisId);
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {

                        Console.WriteLine("Error: " + ex.Message);
                    }

                }


                return diagnosisIds;



            }
            public string Findtreatmentdecription(int Diagnoses_id, string Patient_Number, MySqlConnection conn)
            {
                string query = "SELECT description FROM treatment WHERE tid = @Diagnoses_id AND pnumber = @Patient_Number";

                using (MySqlCommand mySqlCommand = new MySqlCommand(query, conn))
                {
                    mySqlCommand.Parameters.AddWithValue("@Diagnoses_id", Diagnoses_id);
                    mySqlCommand.Parameters.AddWithValue("@Patient_Number", Patient_Number);

                    string curr_description = null;

                    using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            curr_description = reader.GetString("description");
                        }
                        else
                        {
                            MessageBox.Show($"Diagnosis with ID {Diagnoses_id} not found.");
                        }
                    }

                    return curr_description;
                }
            }

            public List<int> GetDiagnosesIDs(string pnumber, MySqlConnection connection)
            {


                    List<int> diagnosisIds = new List<int>();

                    string query = "SELECT diagid FROM diagnosis WHERE pnumber = @pnumber";

               
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@pnumber", pnumber);

                            try
                            {

                                using (MySqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        int diagnosisId = reader.GetInt32("diagid");
                                        diagnosisIds.Add(diagnosisId);
                                    }
                                }
                            }
                            catch (MySqlException ex)
                            {
                                
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        
                    }

            
                    return diagnosisIds;

            

        }




            public string FindDescription(int Diagnoses_id, string Patient_Number, MySqlConnection conn)
            {
                string query = "SELECT description FROM diagnosis WHERE diagid = @Diagnoses_id AND pnumber = @Patient_Number";

                using (MySqlCommand mySqlCommand = new MySqlCommand(query, conn))
                {
                    mySqlCommand.Parameters.AddWithValue("@Diagnoses_id", Diagnoses_id);
                    mySqlCommand.Parameters.AddWithValue("@Patient_Number", Patient_Number);

                    string curr_description = null;

                    using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            curr_description = reader.GetString("description");
                        }
                        else
                        {
                            MessageBox.Show($"Diagnosis with ID {Diagnoses_id} not found.");
                        }
                    }

                    return curr_description;
                }
            }




            public void adddescription(string pnumber, string dnumber, string description, MySqlConnection connection)
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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
        //}    }
        public class Appointment
        {
            private const int MaxAppointmentsPerDay = 4;
            public static bool deleteAppointment(int AppointID, DataTable dt)
            {
                try
                {
                    string query = "DELETE FROM appointment WHERE Appid = @Appid";

                    using (MySqlCommand cmd = new MySqlCommand(query, classes.db.Instance.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@Appid", AppointID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Remove the deleted appointment from the DataTable
                            DataRow[] rows = dt.Select("Appid = " + AppointID);
                            if (rows.Length > 0)
                            {
                                dt.Rows.Remove(rows[0]);
                            }
                        }

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }

            public static void viewAppointments(DataTable dt)
            {
                try
                {

                    string query = "SELECT docnumber, patnumber, date,Appid FROM appointment";
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
            public void bookAppointment(string doctorNumber, string patientNumber, DateTime date,MySqlConnection connection)
            {
                if (!DoctorWorksOnDay(doctorNumber, date.DayOfWeek.ToString(),connection))
                {
                    MessageBox.Show("Doctor does not work on this day.");
                    return;
                }

                if (IsMaxAppointmentsReached(doctorNumber, date.Date,connection))
                {
                    MessageBox.Show("Doctor already has the maximum number of appointments for this day.");
                    return;
                }

                string query = "INSERT INTO appointment (docnumber, patnumber, date) VALUES (@doctorNumber, @patientNumber, @date)";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@doctorNumber", doctorNumber);
                    cmd.Parameters.AddWithValue("@patientNumber", patientNumber);
                    cmd.Parameters.AddWithValue("@date", date);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Appointment added successfully!");
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add appointment.");
                    }
                }
            }

            private bool DoctorWorksOnDay(string doctorNumber, string selectedDay,MySqlConnection connection)
            {
                List<string> workdays = GetDoctorWorkdays(doctorNumber,connection);
                return workdays.Contains(selectedDay);
            }

            private List<string> GetDoctorWorkdays(string doctorNumber,MySqlConnection connection)
            {
                List<string> workdays = new List<string>();

                string query = "SELECT Day FROM workdays WHERE Wid IN (SELECT Wid FROM doctor_workdays WHERE did = @doctorNumber)";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@doctorNumber", doctorNumber);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string day = reader.GetString("Day");
                            workdays.Add(day);
                        }
                    }
                }

                return workdays;
            }

            private bool IsMaxAppointmentsReached(string doctorNumber, DateTime date,MySqlConnection connection)
            {
                string query = "SELECT COUNT(*) AS NumAppointments FROM appointment WHERE docnumber = @doctorNumber AND date = @date";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@doctorNumber", doctorNumber);
                    cmd.Parameters.AddWithValue("@date", date);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int numAppointments = reader.GetInt32("NumAppointments");
                            if (numAppointments > MaxAppointmentsPerDay)
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
        }
    }
}



