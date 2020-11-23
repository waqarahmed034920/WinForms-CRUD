using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TaskManagementSystem.Infrastructure.Interface;
using TaskManagementSystem.Model;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        string connectionString;
        public CategoryRepository()
        {
            this.connectionString = Properties.Settings.Default.ConnectionString;
        }
        public bool Delete(int Id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = this.connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "delete  from Category where id = " + Id.ToString();

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

        public List<Category> GetAll()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = this.connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from Category";
            SqlDataReader myreader = command.ExecuteReader();          
            List<Category> CategoryList = new List<Category>();
            while (myreader.Read())
            {
                Category objcategory = new Category();
                objcategory.Id = Convert.ToInt32(myreader["id"].ToString());
                objcategory.Name = myreader["name"].ToString();
                objcategory.Discription = myreader["description"].ToString();
                CategoryList.Add(objcategory); 
            }
            myreader.Close();
            connection.Close();
            return CategoryList;
        }

        Category IRepository<Category>.GetSingle(int Id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = this.connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from Category where id=" + Id.ToString();
            SqlDataReader myreader = command.ExecuteReader();
            Category objcategory = null;
            while (myreader.Read())
            {
                objcategory = new Category();
                objcategory.Id = Convert.ToInt32(myreader["id"].ToString());
                objcategory.Name = myreader["name"].ToString();
                objcategory.Discription = myreader["description"].ToString();
            }
            myreader.Close();
            connection.Close();
            return objcategory;
        }

        bool IRepository<Category>.Insert(Category objT)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = this.connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "insert into Category(Name,Discripton) values('" + objT.Name + "','" + objT.Discription + "')";

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

        bool IRepository<Category>.Update(Category objT)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = this.connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "update Category set Name = '" + objT.Name + "' ,Discription ='" + objT.Discription + "' where id = '" + objT.Id + "'";

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
    }
    
}
