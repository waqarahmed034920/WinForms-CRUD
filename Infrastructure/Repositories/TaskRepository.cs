using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TaskManagementSystem.Model;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class TaskRepository
    {
        public bool Insert(Task objTask)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "insert into Tasks(task,description,status) values('" + objTask.TaskName + "','" + objTask.Description + "','" + objTask.Status + "')";

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
        public bool Update(Task objTask)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "update Tasks set task = '" + objTask.TaskName + "', description = '" + objTask.Description + "', status = '" + objTask.Status + "' where id =  '" + objTask.Id + "'";

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
            connection.ConnectionString = "Server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from Tasks where id = " + id.ToString();
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

        public Task GetSingle(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from Tasks where id = " + id.ToString();
            SqlDataReader myReader = command.ExecuteReader();
            Task objTask = null;
            while (myReader.Read())
            {
                objTask = new Task();
                objTask.Id = Convert.ToInt32(myReader["id"]);
                objTask.TaskName = myReader["task"].ToString();
                objTask.Description = myReader["description"].ToString();
                objTask.Status = myReader["status"].ToString();
            }

            myReader.Close();
            connection.Close();

            return objTask;

        }

        public List<Task> GetAll()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from Tasks";
            SqlDataReader myReader = command.ExecuteReader();
            List<Task> tasklist = new List<Task>();
            while (myReader.Read())
            {
                Task objtask = new Task();
                objtask.Id = Convert.ToInt32(myReader["id"]);
                objtask.TaskName = myReader["task"].ToString();
                objtask.Description = myReader["description"].ToString();
                objtask.Status = myReader["status"].ToString();
                tasklist.Add(objtask);
            }

            myReader.Close();
            connection.Close();

            return tasklist;

        }
    }
}
