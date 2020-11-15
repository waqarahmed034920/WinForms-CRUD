using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TaskManagementSystem.Model;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class PersonRepositories
    {
       

        public bool insert(Person objPerson)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "insert into person(FirstName,lastName,Address,Phone,Email) values('" + objperson.FirstName + "','" + objperson.LastName + "','" + objperson.Address + "','" + objperson.Phone + "','" + objperson.Email + "')";

            int noOfRowsAffected = command.ExecuteNonQuery();
            connection.Close();
            if (noOfRowsAffected >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool update(Person objPerson)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "update person set FirstName = '" + objupdateper.FirstName + "' ,lastName ='" + objupdateper.LastName + "',Address = '" + objupdateper.Address + "', phone= '" + objupdateper.Phone + "', Email='" + objupdateper.Email + "' where id = '" + objupdateper.Id + "'";

            int noOfRowsAffected = command.ExecuteNonQuery();
            connection.Close();
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
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "delete  from person where id = " + id.ToString();

            int noOfRowsAffected = command.ExecuteNonQuery();
            connection.Close();
            if (noOfRowsAffected >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Person Getsingle(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from person where id=" + id.ToString();
            SqlDataReader myreader = command.ExecuteReader();
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
            connection.Close();
            return objPerson;
        }

        public List<Person> GetAll()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from person";
            SqlDataReader myreader = command.ExecuteReader();
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
            connection.Close();
            return personlist;
        }
    }

}
