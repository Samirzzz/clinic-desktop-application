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
            private string mysqlconn = "server=localhost; user=root; database=clinic-system; password=1234; pooling=true;";
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
        public interface IMessageService
        {
            void show_messages();
            void setmessage(string message);
            void setTitle(string title);
        }


        public class Messages : IMessageService
        {
            public string message;
            public string title;

            public Messages()
            {

            }
            public Messages(string message, string title)
            {
                this.message = message;
                this.title = title;
            }
            public void show_messages()
            {
                MessageBox.Show(message, title);
            }
            public void setmessage(string message)
            {
                this.message = message;
            }
            public void setTitle(string title)
            {
                this.title = title;
            }
        }

        public class Patient
        {

            public int pid;
            public string name;
            public string number;

            IMessageService messages;


            public Patient(IMessageService messages)
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
                    messages.setmessage("No empty field is allowed");
                    messages.setTitle("Validation error");
                    messages.show_messages();
                    return false;
                }
                else if (number.Length < 11)
                {
                    messages.setmessage("Number must be at least 11 characters long");
                    messages.setTitle("Validation error");
                    messages.show_messages();
                    return false;
                }
                else
                {
                    setnumber(number);
                    return true;
                }
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
                                investigation treat = new investigation(number, docnumber);
                                //PatientReport rep = new PatientReport(number,docnumber);
                                diagnosis.Show();
                                hide.Hide();
                                connection.Close();

                            }
                            else
                            {
                                messages.setmessage("Patient with number " + number + " not found.");
                                messages.setTitle("Error");
                                messages.show_messages();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    messages.setmessage("Error:  " + ex.Message);
                    messages.setTitle("Error");
                    messages.show_messages();
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

            IMessageService messages;

            public Doctor(IMessageService messages)
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
                            messages.setmessage("Invalid login Credentials")  ;
                            messages.setTitle("Error");
                            messages.show_messages();
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
            public bool validatePassword(string password,string cpassword)
            {
                if(password == null || password.Length < 5)
                {
                    messages.setmessage("Password length is should be more than 5");
                    messages.setTitle("Validation Error");
                    messages.show_messages();
                    return false;
                }
                else if(password!=cpassword)
                {
                    messages.setmessage("Passwords dont match");
                    messages.setTitle("Validation Error");
                    messages.show_messages();
                    return false;
                }
                setpassword(password);
                return true;
            }
            public bool validatenumber(string number)
            {

                if (string.IsNullOrEmpty(number))
                {
                    messages.setmessage("No empty field is allowed");
                    messages.setTitle("Validation error");
                    messages.show_messages();
                    return false;
                }
                else if (number.Length < 11)
                {
                    messages.setmessage("Number must be at least 11 characters long");
                    messages.setTitle("Validation error");
                    messages.show_messages();
                    
                    return false;
                }
                else
                {
                    setnumber(number);
                    return true;
                }
            }
            public void adddoctor(string name, string number, string spec, List<string> workdays,MySqlConnection connection,string password)
            {
                try
                {
                    string query = "INSERT INTO doctor (name, number, spec,password) VALUES (@name, @number, @spec,@password)";
                    MySqlCommand mySqlCommand = new MySqlCommand(query,connection);
                    mySqlCommand.Parameters.AddWithValue("@name", name);
                    mySqlCommand.Parameters.AddWithValue("@number", number);
                    mySqlCommand.Parameters.AddWithValue("@spec", spec);
                    mySqlCommand.Parameters.AddWithValue("@password", password);


                    int rowsAffected = mySqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                    messages.setmessage("User added Successfully!");
                    messages.setTitle("Doctor Registration");
                    messages.show_messages();
                        foreach (string workday in workdays)
                        {
                            query = "INSERT INTO doctor_workdays (did, Wid) SELECT doctor.number, workdays.Wid FROM doctor, workdays WHERE doctor.number = @number AND workdays.Day = @workday";
                            MySqlCommand workdayCommand = new MySqlCommand(query, connection);
                            workdayCommand.Parameters.AddWithValue("@number", number);
                            workdayCommand.Parameters.AddWithValue("@workday", workday);

                            int workdayRowsAffected = workdayCommand.ExecuteNonQuery();
                            //connection.Close();
                            if (workdayRowsAffected <= 0)
                            {
                                messages.setmessage("Failed to add workday for doctor.");
                                messages.setTitle("Doctor Registration Error");
                                messages.show_messages();
                            }
                        }
                    }
                    else
                    {
                        messages.setmessage("Failed to add user.");
                        messages.setTitle("Doctor Registration Error");
                        messages.show_messages();
                    }
                }
                catch (Exception ex)
                {
                    messages.setmessage("error:  "+ex.Message);
                    messages.setTitle("Doctor Registration Error");
                    messages.show_messages();

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
                                messages.setmessage("doctor with number  " + number+" not found");
                                messages.setTitle("Doctor search Error");
                                messages.show_messages();
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    messages.setmessage("error:  " + ex.Message);
                    messages.setTitle("Doctor Registration Error");
                    messages.show_messages();
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
            public void updateDoctorWorkingDays(string doctorNumber, List<string> workdays, MySqlConnection connection)
            {
                try
                {
                    string deleteQuery = "DELETE FROM doctor_workdays WHERE did = @doctorNumber";
                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@doctorNumber", doctorNumber);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (string workday in workdays)
                    {
                        string insertQuery = "INSERT INTO doctor_workdays (did, Wid) SELECT doctor.number, workdays.Wid FROM doctor, workdays WHERE doctor.number = @doctorNumber AND workdays.Day = @workday";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@doctorNumber", doctorNumber);
                            insertCmd.Parameters.AddWithValue("@workday", workday);
                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    messages.setmessage("Working days updated successfully! ");
                    messages.setTitle("done");
                    messages.show_messages();
                }
                catch (Exception ex)
                {
                    messages.setmessage("error:  " + ex.Message);
                    messages.setTitle("error");
                    messages.show_messages();
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
                    
                    messages.setmessage("error:  " + ex.Message);
                    messages.setTitle("Error");
                    messages.show_messages(); 
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
                    messages.setmessage("error:  " + ex.Message);
                    messages.setTitle("Error");
                    messages.show_messages();
                }
             
               b.Text = doctorName;


            }
        }

        public interface Investigation
        {
            string getdiagnosis();
            void setdiagnosis(string diagnosis);
            void treatment(CheckBox rb1, CheckBox rb2, CheckBox rb3, CheckBox rb4, CheckBox rb5,
               CheckBox rb6, CheckBox rb7, CheckBox rb8, CheckBox rb9, CheckBox rb10,
               CheckBox rb11, CheckBox rb12, CheckBox rb13, CheckBox rb14, CheckBox rb15,
               CheckBox rb16, CheckBox rb17, CheckBox rb18, CheckBox rb19, CheckBox rb20,
               CheckBox rb21, CheckBox rb22, CheckBox rb23, CheckBox rb24, CheckBox rb25,
               CheckBox rb26, CheckBox rb27, CheckBox rb28, CheckBox rb29, CheckBox rb30,
               CheckBox rb31, CheckBox rb32, CheckBox rb33, CheckBox rb34, CheckBox rb35,
               CheckBox rb36, CheckBox rb37, CheckBox rb38);
        }
        public class singlesinvestigation : Investigation
        {

            public string getdiagnosis()
            {
                return "singles investigation";

            }


            public void setdiagnosis(string diagnosis)
            {
                diagnosis = "single";
            }
            public void treatment(CheckBox rb1, CheckBox rb2, CheckBox rb3, CheckBox rb4, CheckBox rb5,
                            CheckBox rb6, CheckBox rb7, CheckBox rb8, CheckBox rb9, CheckBox rb10,
                            CheckBox rb11, CheckBox rb12, CheckBox rb13, CheckBox rb14, CheckBox rb15,
                            CheckBox rb16, CheckBox rb17, CheckBox rb18, CheckBox rb19, CheckBox rb20,
                            CheckBox rb21, CheckBox rb22, CheckBox rb23, CheckBox rb24, CheckBox rb25,
                            CheckBox rb26, CheckBox rb27, CheckBox rb28, CheckBox rb29, CheckBox rb30,
                            CheckBox rb31, CheckBox rb32, CheckBox rb33, CheckBox rb34, CheckBox rb35,
                            CheckBox rb36, CheckBox rb37, CheckBox rb38)
            {

                rb1.Text = "CBC";
                rb2.Text = "PT";
                rb3.Text = "Coomb's (Direct)";
                rb4.Text = "T. protien";
                rb5.Text = "Creat. Clearance";
                rb6.Text = "B2 Microglblin";
                rb7.Text = "Mg++";
                rb8.Text = "Urine analysis";
                rb38.Text = "LDH";
                rb10.Text = "PTT";
                rb11.Text = "Coomb's (Indirect)";
                rb12.Text = "Albumin";
                rb13.Text = "Na+";
                rb14.Text = "Cholestrol";
                rb15.Text = "Ph++";
                rb16.Text = "stool analysis";
                rb17.Text = "Glucose";
                rb18.Text = "ALP";
                rb19.Text = "Urea";
                rb20.Text = "K+";
                rb21.Text = "Trigs";
                rb22.Text = "Amylase";
                rb23.Text = "CSF examination";
                rb24.Text = "Retics";
                rb25.Text = "LDL";
                rb26.Text = "AST";
                rb27.Text = "Bil (T)";
                rb28.Text = "Creatinine";
                rb29.Text = "Ca (total)";
                rb30.Text = "Hdl";
                rb31.Text = "Lipase";
                rb32.Text = "ESR";
                rb33.Text = "ALT";
                rb34.Text = "Bil (D)";
                rb35.Text = "Uric acid";
                rb36.Text = "Ca++ (i)";
                rb37.Text = "Fibrinogen";
                rb38.Text = "CBC with manual differantial";



            }
        }
        public class Chemotherapyinvestigation : Investigation
        {
            public string getdiagnosis()
            {
                return "chemotherapy investigation";
            }
            public void setdiagnosis(string diagnosis)
            {
                diagnosis = "Cancer";
            }

            public void treatment(CheckBox rb1, CheckBox rb2, CheckBox rb3, CheckBox rb4, CheckBox rb5,
                 CheckBox rb6, CheckBox rb7, CheckBox rb8, CheckBox rb9, CheckBox rb10,
                 CheckBox rb11, CheckBox rb12, CheckBox rb13, CheckBox rb14, CheckBox rb15,
                 CheckBox rb16, CheckBox rb17, CheckBox rb18, CheckBox rb19, CheckBox rb20,
                 CheckBox rb21, CheckBox rb22, CheckBox rb23, CheckBox rb24, CheckBox rb25,
                 CheckBox rb26, CheckBox rb27, CheckBox rb28, CheckBox rb29, CheckBox rb30,
                 CheckBox rb31, CheckBox rb32, CheckBox rb33, CheckBox rb34, CheckBox rb35,
                 CheckBox rb36, CheckBox rb37, CheckBox rb38)
            {

                rb1.Text = "Guided Biopsy CBC-PT";
                rb2.Text = "Creatinine";
                rb3.Text = "CBC";
                rb4.Text = "AST";
                rb5.Text = "ALT";
                rb6.Text = "creatinine";
                rb8.Text = "Bil (T)";
                rb9.Text = "CBC";
                rb10.Text = "AST";
                rb11.Text = "ALT";
                rb12.Text = "ALP";
                rb13.Text = "Bil (T)";
                rb14.Text = "Urea";
                rb15.Text = "Creat";
                rb16.Text = "Uric acid";
                rb17.Text = "CBC";
                rb18.Text = "PT";
                rb19.Text = "PTT";
                rb20.Text = "ALT";
                rb21.Text = "AST";
                rb22.Text = "ALP";
                rb23.Text = "Bil(T)";
                rb24.Text = "Urea";
                rb25.Text = "Creat";
            }

        }
        public class microbiologyinvestigation : Investigation
        {
            public string getdiagnosis()
            {
                return "microbiology investigation";
            }
            public void setdiagnosis(string diagnosis)
            {
                diagnosis = "micro";
            }

            public void treatment(CheckBox rb1, CheckBox rb2, CheckBox rb3, CheckBox rb4, CheckBox rb5,
                CheckBox rb6, CheckBox rb7, CheckBox rb8, CheckBox rb9, CheckBox rb10,
                CheckBox rb11, CheckBox rb12, CheckBox rb13, CheckBox rb14, CheckBox rb15,
                CheckBox rb16, CheckBox rb17, CheckBox rb18, CheckBox rb19, CheckBox rb20,
                CheckBox rb21, CheckBox rb22, CheckBox rb23, CheckBox rb24, CheckBox rb25,
                CheckBox rb26, CheckBox rb27, CheckBox rb28, CheckBox rb29, CheckBox rb30,
                CheckBox rb31, CheckBox rb32, CheckBox rb33, CheckBox rb34, CheckBox rb35,
                CheckBox rb36, CheckBox rb37, CheckBox rb38)
            {

                rb1.Text = "HBsAg";
                rb2.Text = "HBe Ab";
                rb3.Text = "CMV IgG";
                rb4.Text = "TB PCR";
                rb5.Text = "Urine C/S";
                rb6.Text = "Throat S. C/S";
                rb7.Text = "HCV AB";
                rb8.Text = "HBc IgM";
                rb9.Text = "HBV PCR (quamt.)";
                rb10.Text = "HCV PCR (quant.)";
                rb11.Text = "Sputum C/S";
                rb12.Text = "Vaginal S. C/S";
                rb13.Text = "HBs Ab";
                rb14.Text = "HBc IgG";
                rb15.Text = "Toxo IgG";
                rb16.Text = "CMV PCR";
                rb17.Text = "Stool C/S";
                rb18.Text = "Pus C/S";
                rb19.Text = "HBe Ag";
                rb20.Text = "CMV IgM";
                rb21.Text = "Toxo IgG";
                rb22.Text = "EBV PCR";
                rb23.Text = "Blood C/S";
                rb24.Text = "Wound C/S";
            }

        }

        public class Medication
        {
            int iid;
            int did;
            int pid;
            string description;
            IMessageService messages;

            public Medication() { }

            public Medication(IMessageService messages)
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

        public class Clinic
        {
            string name;

            IMessageService messages;
             Appointment appointment;
            public Clinic(IMessageService messages)
            {
                appointment = new Appointment(messages);
                this.messages = messages;
            }

            public  Clinic() { }
            string getName()
            {
                return this.name;

            }

            void setName(string name) { this.name = name; }



            public void addpatient(string name, string number, MySqlConnection connection)
            {
                try
                {


                    string query = "INSERT INTO patient (name, number) VALUES (@name, @number)";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                    mySqlCommand.Parameters.AddWithValue("@name", name);
                    mySqlCommand.Parameters.AddWithValue("@number", number);
                    int rowsAffected = mySqlCommand.ExecuteNonQuery();


                    if (rowsAffected > 0)
                    {
                        messages.setmessage("User added successfully!");
                        messages.setTitle("Done");
                        messages.show_messages();
                    }
                    else
                    {
                        messages.setmessage("User add error");
                        messages.setTitle("error");
                        messages.show_messages();
                    }
                }
                catch (Exception ex)
                {
                    messages.setmessage("error: "+ex.Message);
                    messages.setTitle("error");
                    messages.show_messages();
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
                            messages.setmessage("patient with number"+number+"not found");
                            messages.setTitle("error");
                            messages.show_messages();
                        }
                    }
                }

                return curr_patient;
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
                    messages.setmessage("Error:  " + ex.Message);
                    messages.setTitle("Error");
                    messages.show_messages();
                    return false;
                }
            }




        }

        public class Diagnosis
        {
            int diagid;
            int did;
            int pid;
            string description;
            IMessageService messages;
            public Diagnosis() { }

            public Diagnosis(IMessageService messages)
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
                    messages.setmessage( "Error:  "+ex.Message) ;
                    messages.setTitle("Error");
                    messages.show_messages();
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

                    string query = "SELECT tid as id,pnumber,description FROM investigation WHERE pnumber = @number ORDER BY tid DESC";

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
                    messages.setmessage("Error:  " + ex.Message);
                    messages.setTitle("Error");
                    messages.show_messages();
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

                string query = "SELECT tid FROM investigation WHERE pnumber = @pnumber";


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

                        messages.setmessage("Error:  " + ex.Message);
                        messages.setTitle("Error");
                        messages.show_messages();
                    }

                }


                return diagnosisIds;



            }
            public string Findtreatmentdecription(int Diagnoses_id, string Patient_Number, MySqlConnection conn)
            {
                string query = "SELECT description FROM investigation WHERE tid = @Diagnoses_id AND pnumber = @Patient_Number";

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
                            messages.setmessage("Diagnosis with ID:  " + Diagnoses_id+" not found.");
                            messages.setTitle("Error");
                            messages.show_messages();
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

                             messages.setmessage("Error:  " + ex.Message);
                             messages.setTitle("Error");
                             messages.show_messages();
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
                            messages.setmessage("Diagnosis with ID:  " + Diagnoses_id+" not found.");
                            messages.setTitle("Error");
                            messages.show_messages();                        }
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
                            messages.setmessage("Description added successfully!");
                            messages.setTitle("");
                            messages.show_messages();
                        }
                            else
                            {
                            messages.setmessage("error adding the description.");
                            messages.setTitle("Error");
                            messages.show_messages();
                        }
                        }
                    
                }
                catch (Exception ex)
                {
                    messages.setmessage("error: "+ex.Message);
                    messages.setTitle("Error");
                    messages.show_messages();
                }


            }


        }

        public class Appointment
        {
            private const int MaxAppointmentsPerDay = 4;

            IMessageService messages;
            public Appointment(IMessageService messages)
            {
                this.messages = messages;
            }

            public void updateAppointment(string patnumber,int Appid,DataTable dt)
            {
                string query = "UPDATE appointment SET patnumber = @patnumber";
                using (MySqlCommand cmd = new MySqlCommand(query, classes.db.Instance.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@patnumber", patnumber);
         
                    cmd.ExecuteNonQuery();
                }
                DataRow[] rows = dt.Select("Appid = '" + Appid + "'");
                if (rows.Length > 0)
                {
                    rows[0]["Patnumber"] = patnumber;
                }
            }
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
                    messages.setmessage("Doctor does not work on this day.  ");
                    messages.setTitle("Error");
                    messages.show_messages();
                    return;
                }

                if (IsMaxAppointmentsReached(doctorNumber, date.Date,connection))
                {
                    messages.setmessage("Doctor already has the maximum number of appointments for this day.");
                    messages.setTitle("Error");
                    messages.show_messages();
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
                        messages.setmessage("Appointment added successfully!.");
                        messages.setTitle("");
                        messages.show_messages(); 
                        connection.Close();
                    }
                    else
                    {
                        messages.setmessage("Failed to add appointment.");
                        messages.setTitle("Error");
                        messages.show_messages();
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



