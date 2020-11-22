using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TaskManagementSystem.Model;
using TaskManagementSystem.Infrastructure.Interface;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class PersonRepositories : IRepository<Person>
    {
       // string connnectionstring;
        //private string connectionString;
        public SqlCommand cmd;

        public PersonRepositories()
        {
            //this.connectionString = Properties.Settings.Default.ConnectionString;
            //System.Windows.Forms.MessageBox.Show(this.connectionString);

            SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
        }

        public bool Insert(Person objPerson)
        {
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = this.connectionString;
            cmd.Connection.Open();

           // SqlCommand command = new SqlCommand();
            //command.Connection = connection;
           // command.CommandType = CommandType.Text;
            cmd.CommandText = "insert into person(FirstName,lastName,Address,Phone,Email) values('" + objPerson.FirstName + "','" + objPerson.LastName + "','" + objPerson.Address + "','" + objPerson.Phone + "','" + objPerson.Email + "')";

            int noOfRowsAffected = cmd.ExecuteNonQuery();
           cmd.Connection.Close();
            if (noOfRowsAffected >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Update(Person objPerson)
        {
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = this.connectionString;
            cmd.Connection.Open();

           // SqlCommand command = new SqlCommand();
           // command.Connection = connection;
           // command.CommandType = CommandType.Text;
            cmd.CommandText = "update person set FirstName = '" + objPerson.FirstName + "' ,lastName ='" + objPerson.LastName + "',Address = '" + objPerson.Address + "', phone= '" + objPerson.Phone + "', Email='" + objPerson.Email + "' where id = '" + objPerson.Id + "'";

            int noOfRowsAffected = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            if (noOfRowsAffected >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = this.connectionString;
            cmd.Connection.Open();

            //SqlCommand command = new SqlCommand();
            //command.Connection = connection;
            //command.CommandType = CommandType.Text;
            cmd.CommandText = "delete  from person where id = " + id.ToString();

            int noOfRowsAffected = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            if (noOfRowsAffected >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Person GetSingle(int id)
        {
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = this.connectionString;
            cmd.Connection.Open();

            //SqlCommand command = new SqlCommand();
            //command.Connection = connection;
            //command.CommandType = CommandType.Text;
            cmd.CommandText = "select * from person where id=" + id.ToString();
            SqlDataReader myreader = cmd.ExecuteReader();
            Person objPerson = null;
            while (myreader.Read())
            {
                objPerson = new Person();
                objPerson.Id = Convert.ToInt32(myreader["id"].ToString());
                objPerson.FirstName = myreader["firstname"].ToString();
                objPerson.LastName = myreader["lastname"].ToString();
                objPerson.Address = myreader["address"].ToString();
                objPerson.Phone = myreader["phone"].ToString();
                objPerson.Email = myreader["email"].ToString();

            }
            myreader.Close();
            cmd.Connection.Close();
            return objPerson;
        }
        public List<Person> GetAll()
        {
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = this.connectionString;
            cmd.Connection.Open();

            //SqlCommand command = new SqlCommand();
           // command.Connection = connection;
            //command.CommandType = CommandType.Text;
            cmd.CommandText = "select * from person";
            SqlDataReader myreader = cmd.ExecuteReader();
            List<Person> personlist = new List<Person>();
            while (myreader.Read())
            {
                Person objperson = new Person();
                objperson.Id = Convert.ToInt32(myreader["id"].ToString());
                objperson.FirstName = myreader["firstname"].ToString();
                objperson.LastName = myreader["lastname"].ToString();
                objperson.Address = myreader["address"].ToString();
                objperson.Phone = myreader["phone"].ToString();
                objperson.Email = myreader["email"].ToString();
                personlist.Add(objperson);
            }
            myreader.Close();
            cmd.Connection.Close();
            return personlist;
        }
    }

}
