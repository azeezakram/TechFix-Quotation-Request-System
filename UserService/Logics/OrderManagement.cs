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
    public class OrderManagement
    {
        public List<Order> GetAllOrders()
        {

            List<Order> orders = new List<Order>();

            using (SqlConnection newConnection = DataAccessLayer.OpenConnection())
            {
                newConnection.Open();
                SqlCommand command = new SqlCommand("GetAllOrders", newConnection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Order order = new Order
                    {
                        orderId = reader["orderId"] != DBNull.Value ? (int)reader["orderId"] : 0,
                        supplierId = reader["supplierId"] != DBNull.Value ? (int)reader["supplierId"] : 0,
                        supplierName = reader["supplierName"] != DBNull.Value ? (string)reader["supplierName"] : null,
                        totalAmount = reader["totalAmount"] != DBNull.Value ? (decimal)reader["totalAmount"] : 0,
                        orderDate = reader["orderDate"] != DBNull.Value ? (DateTime)reader["orderDate"] : DateTime.MinValue,   

                    };
                    orders.Add(order);
                }
            }
            return orders;
        }

        public List<OrderItem> GetAllOrderItems()
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (SqlConnection newConnection = DataAccessLayer.OpenConnection())
            {
                newConnection.Open();
                SqlCommand command = new SqlCommand("GetAllOrderItems", newConnection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    OrderItem orderItem = new OrderItem
                    {
                        orderItemId = reader["orderItemId"] != DBNull.Value ? (int)reader["orderItemId"] : 0,
                        orderId = reader["orderId"] != DBNull.Value ? (int)reader["orderId"] : 0,
                        productId = reader["productId"] != DBNull.Value ? (int)reader["productId"] : 0,
                        productName = reader["name"] != DBNull.Value ? (string)reader["name"] : null,
                        quantity = reader["quantity"] != DBNull.Value ? (int)reader["quantity"] : 0,
                        unitPrice = reader["unitPrice"] != DBNull.Value ? (decimal)reader["unitPrice"] : 0,
                        subTotal = reader["subTotal"] != DBNull.Value ? (decimal)reader["subTotal"] : 0,

                    };
                    orderItems.Add(orderItem);
                }
            }
            return orderItems;
        }


        public int CreateNewOrder(Order newOrder, List<OrderItem> orderItemList)
        {
            int maxOrderId = 0;

            using (SqlConnection newConnection = DataAccessLayer.OpenConnection())
            {
                try
                {
                    newConnection.Open();

                    SqlCommand orderCommand = new SqlCommand("CreateNewOrder", newConnection);
                    orderCommand.CommandType = CommandType.StoredProcedure;

                    orderCommand.Parameters.AddWithValue("@supplierId", newOrder.supplierId);
                    SqlParameter outputIdParam = orderCommand.Parameters.Add("@getOrderId", SqlDbType.Int);
                    outputIdParam.Direction = ParameterDirection.Output;

                    orderCommand.ExecuteNonQuery();
                    maxOrderId = Convert.ToInt32(outputIdParam.Value);

                    SqlCommand updateTotalAmountCommand = new SqlCommand("UpdateOrderTotalAmount", newConnection);
                    updateTotalAmountCommand.CommandType = CommandType.StoredProcedure;

                    SqlCommand updateStockCommand = new SqlCommand("UpdateStockCommand", newConnection);
                    updateStockCommand.CommandType = CommandType.StoredProcedure;

                    foreach (OrderItem item in orderItemList)
                    {
                        SqlCommand orderItemCommand = new SqlCommand("AddItemToOrder", newConnection);
                        orderItemCommand.CommandType = CommandType.StoredProcedure;

                        orderItemCommand.Parameters.Clear();
                        orderItemCommand.Parameters.AddWithValue("@orderId", maxOrderId);
                        orderItemCommand.Parameters.AddWithValue("@productId", item.productId);
                        orderItemCommand.Parameters.AddWithValue("@unitPrice", item.unitPrice);
                        orderItemCommand.Parameters.AddWithValue("@quantity", item.quantity);

                        decimal subTotal = item.unitPrice * item.quantity;
                        orderItemCommand.Parameters.AddWithValue("@subTotal", subTotal);

                        orderItemCommand.ExecuteNonQuery();

                        updateStockCommand.Parameters.Clear();
                        updateStockCommand.Parameters.AddWithValue("@productId", item.productId);
                        updateStockCommand.Parameters.AddWithValue("@quantity", item.quantity);
                        updateStockCommand.ExecuteNonQuery();

                        updateTotalAmountCommand.Parameters.Clear();
                        updateTotalAmountCommand.Parameters.AddWithValue("@maxOrderId", maxOrderId);
                        updateTotalAmountCommand.Parameters.AddWithValue("@subTotal", subTotal);

                        updateTotalAmountCommand.ExecuteNonQuery();
                    }

                    return maxOrderId;
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while processing the order", ex);
                }
                finally
                {
                    if (newConnection.State == ConnectionState.Open)
                    {
                        newConnection.Close();
                    }
                }
            }
        }


    }
}