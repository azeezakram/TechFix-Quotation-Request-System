using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using UserService.DataAccess;
using UserService.Models;
using System.Data.Common;
using System.Collections.ObjectModel;
using System.Configuration;

namespace UserService.Logics
{
    public class QuotationManagement
    {
        public List<Quotation> GetAllQuotations()     
        { 
            List<Quotation> quotations = new List<Quotation>();

            using (SqlConnection newConnection = DataAccessLayer.OpenConnection())
            {
                newConnection.Open();
                SqlCommand command = new SqlCommand("GetAllQuotations", newConnection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Quotation quotation = new Quotation
                    {
                        quotationId = reader["quotationId"] != DBNull.Value ? (int)reader["quotationId"] : 0,
                        supplierId = reader["supplierId"] != DBNull.Value ? (int)reader["supplierId"] : 0,
                        supplierName = reader["supplierName"] != DBNull.Value ? (string)reader["supplierName"] : string.Empty,
                        requestDate = reader["requestDate"] != DBNull.Value ? (DateTime)reader["requestDate"] : DateTime.MinValue,
                        approveDate = reader["approveDate"] != DBNull.Value ? (DateTime?)reader["approveDate"] : null

                    };
                    quotations.Add(quotation);
                }
            }
            return quotations;
        }

        public List<QuotationDetail> GetAllQuotationDetails()
        {

            List<QuotationDetail> quotationDetails = new List<QuotationDetail>();

            using (SqlConnection newConnection = DataAccessLayer.OpenConnection())
            {
                newConnection.Open();
                SqlCommand command = new SqlCommand("GetAllQuotationDetails", newConnection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    QuotationDetail quotationDetailRecord = new QuotationDetail
                    {
                        quotationDetailId = reader["quotationDetailId"] != DBNull.Value ? (int)reader["quotationDetailId"] : 0,
                        quotationId = reader["quotationId"] != DBNull.Value ? (int)reader["quotationId"] : 0,
                        productId = reader["productId"] != DBNull.Value ? (int)reader["productId"] : 0,
                        name = reader["name"] != DBNull.Value ? (string)reader["name"] : string.Empty,
                        unitPrice = reader["unitPrice"] != DBNull.Value ? (decimal)reader["unitPrice"] : 0,
                        quantity = reader["quantity"] != DBNull.Value ? (int)reader["quantity"] : 0,
                        supplierDiscount = reader["supplierDiscount"] != DBNull.Value ? (decimal)reader["supplierDiscount"] : 0,
                        requestDiscount = reader["requestDiscount"] != DBNull.Value ? (decimal)reader["requestDiscount"] : 0,
                        

                    };
                    quotationDetails.Add(quotationDetailRecord);
                }
            }
            return quotationDetails;
        }

        public int CreateNewQuotationRequest(Quotation newQuotation, List<QuotationDetail> itemList)
        {
            
            int maxQuotationId = 0;

            using (SqlConnection newConnection = DataAccessLayer.OpenConnection())
            {
                try
                {
                    newConnection.Open();

                    SqlCommand command = new SqlCommand("CreateNewQuotation", newConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@supplierId", newQuotation.supplierId);
                    // command.Parameters.AddWithValue("@requestDate", newQuotation.requestDate); // If needed
                    SqlParameter outputIdParam = command.Parameters.Add("@getQuotationId", SqlDbType.Int);
                    outputIdParam.Direction = ParameterDirection.Output;

                    // Execute and get the new quotation ID
                    command.ExecuteNonQuery();
                    maxQuotationId = Convert.ToInt32(outputIdParam.Value);


                    Console.WriteLine(maxQuotationId);

                    // Insert quotation details
                    foreach (QuotationDetail item in itemList)
                    {
                        SqlCommand detailCommand = new SqlCommand("AddItemToQuotation", newConnection);
                        detailCommand.CommandType = CommandType.StoredProcedure;

                        // Add parameters for each quotation detail
                        detailCommand.Parameters.AddWithValue("@quotationId", maxQuotationId);
                        detailCommand.Parameters.AddWithValue("@productId", item.productId);
                        detailCommand.Parameters.AddWithValue("@unitPrice", item.unitPrice);
                        detailCommand.Parameters.AddWithValue("@quantity", item.quantity);
                        detailCommand.Parameters.AddWithValue("@supplierDiscount", item.supplierDiscount);
                        detailCommand.Parameters.AddWithValue("@requestDiscount", item.requestDiscount ?? (object)DBNull.Value);

                        detailCommand.ExecuteNonQuery();
                    }

                    return maxQuotationId; 
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while processing the quotation request", ex);
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

        public int UpdateRequestDiscount(int quotationDetailId, decimal requestDiscount)
        {
            using (SqlConnection newConnection = DataAccessLayer.OpenConnection())
            {
                try
                {
                    newConnection.Open();

                    SqlCommand command = new SqlCommand("UpdateRequestDiscount", newConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@quotationDetailId", quotationDetailId);
                    command.Parameters.AddWithValue("@requestDiscount", requestDiscount);



                    int result = command.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while updating the request discount of quotaion detail id {quotationDetailId}", ex);
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

        public int SetQuotationApproved(int quotationId)
        {
            using (SqlConnection newConnection = DataAccessLayer.OpenConnection())
            {
                try
                {
                    newConnection.Open();

                    SqlCommand command = new SqlCommand("SetQuotationApproved", newConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@quotationId", quotationId);
                    command.Parameters.AddWithValue("@approveDate", DateTime.Now);



                    int result = command.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while approving quotaion id {quotationId}", ex);
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