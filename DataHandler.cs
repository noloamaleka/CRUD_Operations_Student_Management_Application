using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace PRG262_Project
{
    class DataHandler
    {
        string ConnectionString = "Data Source=localhost;Initial Catalog=StudentInfo;Integrated Security=True";
        public DataTable ReadLogin()
        {
            DataTable data = new DataTable();
            string query = @"SELECT * FROM Users";
            SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionString);
            adapter.Fill(data);
            data.AcceptChanges();
            return data;
        }
        // ADD
        public void AddInfo(int ID, string FirstName, string LastName, DateTime DOB, 
            string Gender, string Phone, string Address, string CourseCode, byte[] Image)
        {
            
            string query = "INSERT INTO [dbo].[Students]"+
           "([StudentID],[FirstName],[LastName],[DOB],[Gender],[Phone],[Address]," +
           "[CourseCode],[StudentImage])" +
           $" VALUES('{ID}', '{FirstName}', '{LastName}', '{DOB}', '{Gender}', " +
           $"'{Phone}', '{Address}', '{CourseCode}', @img)";
            string message = "Add Successful";
            
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@img", SqlDbType.Image);//CHANGED TO IMAGE DATATYPE...
                command.Parameters["@img"].Value = Image;
                command.ExecuteNonQuery();
                MessageBox.Show(message);
                connection.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        // Update
        public string[] UpdateInfo(int ID, string FirstName, string LastName, DateTime DOB,
            string Gender, string Phone, string Address, string CourseCode)
        {

            string query = $"UPDATE Students SET FirstName ='{FirstName}',LastName = '{LastName}'," +
                $"DOB = '{DOB}',Gender = '{Gender}',Phone = '{Phone}', Address = '{Address}'," +
                $"CourseCode = '{CourseCode}' WHERE StudentID = '{ID}'";
            string message = "Update Successful";
            string[] InfoQuery = { query, message };
            return InfoQuery;
        }
        //Delete
        public string[] Delete(int ID)
        {

            string query = $"DELETE FROM Students WHERE StudentID = '{ID}'";
            string message = "Delete Successful";
            string[] InfoQuery = { query, message };
            return InfoQuery;
        }
        public void ExecuteQuery(string[] InfoQuery)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(InfoQuery[0], connection);
                command.ExecuteNonQuery();
                MessageBox.Show(InfoQuery[1]);
                connection.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        public DataTable Search(int ID)
        {
            DataTable data = new DataTable();
            try
            {
                
                string query = $"SELECT * FROM Students WHERE StudentID = '{ID}'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionString);
                adapter.Fill(data);
                data.AcceptChanges();
                
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                
            }
            return data;
        }
        public List<User> ReadToList(List<string> RawDataPeole)
        {
            List<User> people = new List<User>();
            foreach (string item in RawDataPeole)
            {
                string[] Format = item.Split(',');
                people.Add(new User(Format[0], Format[1]));
            }
            return people;
        }
        public List<string> WriteToFile(List<User> users)
        {
            List<string> RawData = new List<string>();
            foreach (User person in users)
            {
                string line = string.Format("{0},{1}", person.UserName, person.Password);
                RawData.Add(line);


            }

            return RawData;
        }
    }
}
