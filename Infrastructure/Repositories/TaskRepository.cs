using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TaskManagementSystem.Infrastructure.Interface;
using TaskManagementSystem.Model;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class TaskRepository : IRepository<Task>
    {
        public SqlCommand cmd;
        // constructor;
        public TaskRepository()
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
        }
        public bool Insert(Task objTask)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "insert into Tasks(task,description,status) values('" + objTask.TaskName + "','" + objTask.Description + "','" + objTask.Status + "')";

                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        public bool Update(Task objTask)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "update Tasks set task = '" + objTask.TaskName + "', description = '" + objTask.Description + "', status = '" + objTask.Status + "' where id =  '" + objTask.Id + "'";

                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

        }
        public bool Delete(int id)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "delete from Tasks where id = " + id.ToString();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public Task GetSingle(int id)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "select * from Tasks where id = " + id.ToString();
                SqlDataReader myReader = cmd.ExecuteReader();
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

                return objTask;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

        }

        public List<Task> GetAll()
        {
            try
            {

                cmd.Connection.Open();

                cmd.CommandText = "select * from Tasks";
                SqlDataReader myReader = cmd.ExecuteReader();
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
                cmd.Connection.Close();
                return tasklist;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }


        }
    }
}
