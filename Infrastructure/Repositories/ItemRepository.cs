using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TaskManagementSystem.Infrastructure.Interface;
using TaskManagementSystem.Model;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        public SqlCommand cmd;
        public ItemRepository()
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
        }
        public bool Delete(int Id)
        {
            cmd.Connection.Open();
            cmd.CommandText = "delete from Item where id = " + Id.ToString();

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

        public List<Item> GetAll()
        {
            cmd.Connection.Open();
            cmd.CommandText = "select * from Item";
            SqlDataReader myreader = cmd.ExecuteReader();
            List<Item> itemlist = new List<Item>();
            while (myreader.Read())
            {
                Item objItem = new Item();
                objItem.Id = Convert.ToInt32(myreader["id"].ToString());
                objItem.Name= myreader["Name"].ToString();
                objItem.Description = myreader["Description"].ToString();
                objItem.CategoryId = Convert.ToInt32(myreader["CategoryId"].ToString());
                objItem.Price = Convert.ToDecimal(myreader["Price"].ToString());
                objItem.Barcode = myreader["Barcode"].ToString();
                objItem.QuantityRemaining  = Convert.ToInt32(myreader["QuantityRemaining"].ToString());
                objItem.ReOrderLevel = Convert.ToInt32(myreader["ReOrderLevel"].ToString());
                itemlist.Add(objItem);
            }
            myreader.Close();
            cmd.Connection.Close();
            return itemlist;
        }

        public Item GetSingle(int Id)
        {
            cmd.Connection.Open();
            cmd.CommandText = "select * from Item where id = " + Id.ToString();
            SqlDataReader myreader = cmd.ExecuteReader();
            Item objItem = null;
            while (myreader.Read())
            {
                objItem = new Item();
                objItem.Id = Convert.ToInt32(myreader["id"].ToString());
                objItem.Name = myreader["Name"].ToString();
                objItem.Description = myreader["Description"].ToString();
                objItem.CategoryId = Convert.ToInt32(myreader["CategoryId"].ToString());
                objItem.Price = Convert.ToDecimal(myreader["Price"].ToString());
                objItem.Barcode = myreader["Barcode"].ToString();
                objItem.QuantityRemaining = Convert.ToInt32(myreader["QuantityRemaining"].ToString());
                objItem.ReOrderLevel = Convert.ToInt32(myreader["ReOrderLevel"].ToString());
            }
            myreader.Close();
            cmd.Connection.Close();
            return objItem;
        }

        public bool Insert(Item objT)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "insert into Item(CategoryId, Name, Description, Barcode, ReOrderLevel, Price, QuantityRemaining)" +
                    " values('" + objT.CategoryId + "','" + objT.Name + "','" + objT.Description + "','"
                    + objT.Barcode + "','" + objT.ReOrderLevel + "','" + objT.Price + "','" + objT.QuantityRemaining + "')";

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
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public bool Update(Item objT)
        {
            cmd.Connection.Open();
            cmd.CommandText = "update Item set Name = '" +
                objT.Name + "' ,CategoryId = '" +
                objT.CategoryId + "' ,Description = '" + 
                objT.Description + "', Barcode = '" + 
                objT.Barcode + "', ReOrderLevel= '" +
                objT.ReOrderLevel + "', QuantityRemaining= QuantityRemaining + " +
                objT.QuantityRemaining + ", Price='" +
                objT.Price + "' where id = '" + objT.Id + "'";

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
    }
}
