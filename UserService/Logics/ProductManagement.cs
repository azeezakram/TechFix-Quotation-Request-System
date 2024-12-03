using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using UserService.DataAccess;
using UserService.Models;

namespace UserService.Logics
{
    public class ProductManagement
    {
        SqlConnection newConnection;
        public ProductManagement() {
            newConnection = new SqlConnection();
        }
        
        public int AddNewProduct(Product newProduct)
        {
            newConnection = DataAccessLayer.OpenConnection();
            SqlCommand newSqlCommand = new SqlCommand("AddNewProduct", newConnection);
            newSqlCommand.CommandType = CommandType.StoredProcedure;
            newSqlCommand.Parameters.AddWithValue("@supplierId", newProduct.supplierId);
            newSqlCommand.Parameters.AddWithValue("@name", newProduct.name);
            newSqlCommand.Parameters.AddWithValue("@unitPrice", newProduct.unitPrice);
            newSqlCommand.Parameters.AddWithValue("@stock", newProduct.stock);
            newSqlCommand.Parameters.AddWithValue("@discount", newProduct.discount);
            newSqlCommand.Parameters.AddWithValue("@updatedAt", DateTime.Now);
            newConnection.Open();
            int insertResult = newSqlCommand.ExecuteNonQuery();
            newConnection.Close();
            return insertResult;
        }

        public List<Product> GetAllProducts()
        {
            DataTable data = new DataTable();
            List<Product> productList = new List<Product>();
            newConnection = DataAccessLayer.OpenConnection();
            SqlCommand newSqlCommand = new SqlCommand("GetAllProducts", newConnection);
            newSqlCommand.CommandType = CommandType.StoredProcedure;
            newConnection.Open();
            SqlDataAdapter newAdapter = new SqlDataAdapter(newSqlCommand);
            newAdapter.Fill(data);

            foreach (DataRow r in data.Rows)
            {
                productList.Add(new Product
                {
                    productId = int.Parse(r["productId"].ToString()),
                    supplierId = int.Parse(r["supplierId"].ToString()),
                    name = r["name"].ToString(),
                    unitPrice = double.TryParse(r["unitPrice"].ToString(), out double unitPrice) ? unitPrice : 0.0,
                    stock = int.Parse(r["stock"].ToString()),
                    discount = double.TryParse(r["discount"].ToString(), out double discount) ? discount : 0.0,
                    updatedAt = DateTime.Parse(r["updatedAt"].ToString()),
                    createdAt = DateTime.Parse(r["createdAt"].ToString())
                });
            }
            newConnection.Close();
            return productList;
        }

        public int UpdateProduct(Product updatedProduct)
        {
            newConnection = DataAccessLayer.OpenConnection();
            SqlCommand command = new SqlCommand("UpdateProduct", newConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@productId", updatedProduct.productId);
            command.Parameters.AddWithValue("@name", updatedProduct.name);
            command.Parameters.AddWithValue("@unitPrice", (decimal)updatedProduct.unitPrice);
            command.Parameters.AddWithValue("@discount", (decimal)updatedProduct.discount);
            command.Parameters.AddWithValue("@stock", updatedProduct.stock);
            command.Parameters.AddWithValue("@updatedAt", DateTime.Now);
            
            newConnection.Open();
            int result = command.ExecuteNonQuery();
            newConnection.Close();
            return result;
        }

        public int DeleteProduct(Product updatedProduct)
        {
            newConnection = DataAccessLayer.OpenConnection();
            SqlCommand command = new SqlCommand("DeleteProduct", newConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@productId", updatedProduct.productId);
            

            newConnection.Open();
            int result = command.ExecuteNonQuery();
            newConnection.Close();
            return result;
        }

        public int ClearTheInventory(int supplierId)
        {
            newConnection = DataAccessLayer.OpenConnection();
            SqlCommand command = new SqlCommand("ClearTheInventory", newConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@supplierId", supplierId);


            newConnection.Open();
            int result = command.ExecuteNonQuery();
            newConnection.Close();
            return result;
        }
    }
}