using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using UserService.Models;
using UserService.DataAccess;

namespace UserService.Logics
{
    public class SupplierManagement
    {
        SqlConnection newConnection;
        public SupplierManagement() {
            newConnection = new SqlConnection();
        }    


        public bool isUsernameNotExists(string username)
        {
            bool exists = false;
            newConnection = DataAccessLayer.OpenConnection();
            newConnection.Open();
            SqlCommand newSqlCommand = new SqlCommand("IsUsernameNotExists", newConnection);
            newSqlCommand.CommandType = CommandType.StoredProcedure;
            newSqlCommand.Parameters.AddWithValue("@username", username);

            object result = newSqlCommand.ExecuteScalar();

            if (result != null && Convert.ToInt32(result) == 1)
            {
                exists = true; 
            }
            else
            {
                exists = false; 
            }

            return exists;
        }


        public string[] GetSupplierUsernameAndPassword(string username)
        {
            string[] userData = new string[3];
            newConnection = DataAccessLayer.OpenConnection();
            newConnection.Open();
            SqlCommand newSqlCommand = new SqlCommand("GetSupplierUsernameAndPassword", newConnection);
            newSqlCommand.CommandType = CommandType.StoredProcedure;
            newSqlCommand.Parameters.AddWithValue("@username", username);

            SqlDataReader reader = newSqlCommand.ExecuteReader();

            while (reader.Read())
            {
                userData[0] = reader["username"] != DBNull.Value ? (string)reader["username"] : null;
                userData[1] = reader["password"] != DBNull.Value ? (string)reader["password"] : null;
                userData[2] = reader["supplierId"] != DBNull.Value ? reader["supplierId"].ToString() : null;
            }

            reader.Close();
            newConnection.Close();

            return userData;

        }


        public int AddNewSupplier(Supplier newSupplier)
        {
            newConnection = DataAccessLayer.OpenConnection();
            SqlCommand newSqlCommand = new SqlCommand("AddNewSupplier", newConnection);
            newSqlCommand.CommandType = CommandType.StoredProcedure;
            newSqlCommand.Parameters.AddWithValue("@supplierName", newSupplier.supplierName);
            newSqlCommand.Parameters.AddWithValue("@username", newSupplier.username);
            newSqlCommand.Parameters.AddWithValue("@password", newSupplier.password);
            newConnection.Open();

            int insertResult = newSqlCommand.ExecuteNonQuery();
            return insertResult;
        }

        public List<Supplier> GetSuppliers()
        {
            DataTable data = new DataTable();
            List<Supplier> supplierList = new List<Supplier>();
            newConnection = DataAccessLayer.OpenConnection();
            SqlCommand newSqlCommand = new SqlCommand("GetSuppliers", newConnection);
            newSqlCommand.CommandType = CommandType.StoredProcedure;
            newConnection.Open();
            SqlDataAdapter newAdapter = new SqlDataAdapter(newSqlCommand);
            newAdapter.Fill(data);

            foreach (DataRow r in data.Rows)
            {
                supplierList.Add(new Supplier
                {
                    supplierId = int.Parse(r["supplierId"].ToString()),
                    supplierName = r["supplierName"].ToString(),
                    username = r["username"].ToString(),
                    password = r["password"].ToString()
                });
            }
            return supplierList;
        }

        public int UpdateSupplier(Supplier updatedSupplier)
        {
            newConnection = DataAccessLayer.OpenConnection();
            SqlCommand newSqlCommand = new SqlCommand("UpdateSupplier", newConnection);
            newSqlCommand.CommandType = CommandType.StoredProcedure;
            newSqlCommand.Parameters.AddWithValue("@supplierId", updatedSupplier.supplierId);
            newSqlCommand.Parameters.AddWithValue("@supplierName", updatedSupplier.supplierName);
            newSqlCommand.Parameters.AddWithValue("@username", updatedSupplier.username);
            newSqlCommand.Parameters.AddWithValue("@password", updatedSupplier.password);
            
            newConnection.Open();
            return newSqlCommand.ExecuteNonQuery();       
        }

        public int DeleteSupplier(int supplierId)
        {
            newConnection = DataAccessLayer.OpenConnection();
            SqlCommand newSqlCommand = new SqlCommand("DeleteSupplier", newConnection);
            newSqlCommand.CommandType = CommandType.StoredProcedure;
            newSqlCommand.Parameters.AddWithValue("@supplierId", supplierId);
            newConnection.Open();
            int result = newSqlCommand.ExecuteNonQuery();
            newConnection.Close();
            return result;
        }

        public int GetSupplierId(int productId) 
        {
            newConnection = DataAccessLayer.OpenConnection();
            SqlCommand newSqlCommand = new SqlCommand("GetSupplierId", newConnection);
            newSqlCommand.CommandType = CommandType.StoredProcedure;
            newSqlCommand.Parameters.AddWithValue("@productId", productId);
            newConnection.Open();
            int result = newSqlCommand.ExecuteNonQuery();
            newConnection.Close();
            return result;
        }
    }
}