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
    public class TechFixStaffManagement
    {

        SqlConnection newConnection;
        public TechFixStaffManagement()
        {
            newConnection = new SqlConnection();
        }


        public bool isStaffUsernameNotExists(string username)
        {
            bool exists = false;
            newConnection = DataAccessLayer.OpenConnection();
            newConnection.Open();
            SqlCommand newSqlCommand = new SqlCommand("IsStaffUsernameNotExists", newConnection);
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


        public string[] GetStaffUsernameAndPassword(string username)
        {
            string[] userData = new string[3];
            newConnection = DataAccessLayer.OpenConnection();
            newConnection.Open();
            SqlCommand newSqlCommand = new SqlCommand("GetStaffUsernameAndPassword", newConnection);
            newSqlCommand.CommandType = CommandType.StoredProcedure;
            newSqlCommand.Parameters.AddWithValue("@username", username);

            SqlDataReader reader = newSqlCommand.ExecuteReader();

            while (reader.Read())
            {
                userData[0] = reader["username"] != DBNull.Value ? (string)reader["username"] : null;
                userData[1] = reader["password"] != DBNull.Value ? (string)reader["password"] : null;
                userData[2] = reader["staffId"] != DBNull.Value ? reader["staffId"].ToString() : null;
            }

            reader.Close();
            newConnection.Close();

            return userData;
        }

        public int AddNewStaff(TechFixStaff newStaff)
        {
            newConnection = DataAccessLayer.OpenConnection();
            SqlCommand newSqlCommand = new SqlCommand("AddNewStaff", newConnection);
            newSqlCommand.CommandType = CommandType.StoredProcedure;
            newSqlCommand.Parameters.AddWithValue("@staffName", newStaff.staffName);
            newSqlCommand.Parameters.AddWithValue("@username", newStaff.username);
            newSqlCommand.Parameters.AddWithValue("@password", newStaff.password);
            newConnection.Open();

            int insertResult = newSqlCommand.ExecuteNonQuery();
            return insertResult;
        }

        public List<TechFixStaff> GetAllStaffs()
        {
            DataTable data = new DataTable();
            List<TechFixStaff> staffList = new List<TechFixStaff>();
            newConnection = DataAccessLayer.OpenConnection();
            SqlCommand newSqlCommand = new SqlCommand("GetAllStaffs", newConnection);
            newSqlCommand.CommandType = CommandType.StoredProcedure;
            newConnection.Open();
            SqlDataAdapter newAdapter = new SqlDataAdapter(newSqlCommand);
            newAdapter.Fill(data);

            foreach (DataRow r in data.Rows)
            {
                staffList.Add(new TechFixStaff
                {
                    staffId = int.Parse(r["staffId"].ToString()),
                    staffName = r["staffName"].ToString(),
                    username = r["username"].ToString(),
                    password = r["password"].ToString()
                });
            }
            return staffList;
        }


        public int UpdateStaff(TechFixStaff updatedStaff)
        {
            newConnection = DataAccessLayer.OpenConnection();
            newConnection.Open();
            SqlCommand newSqlCommand = new SqlCommand("UpdateStaff", newConnection);
            newSqlCommand.CommandType = CommandType.StoredProcedure;
            newSqlCommand.Parameters.AddWithValue("@staffId", updatedStaff.staffId);
            newSqlCommand.Parameters.AddWithValue("@staffName", updatedStaff.staffName);
            newSqlCommand.Parameters.AddWithValue("@username", updatedStaff.username);
            newSqlCommand.Parameters.AddWithValue("@password", updatedStaff.password);

            int result =  newSqlCommand.ExecuteNonQuery();
            newConnection.Close();
            return result;
        }

        public int DeleteStaff(int staffId)
        {
            newConnection = DataAccessLayer.OpenConnection();
            newConnection.Open();
            SqlCommand newSqlCommand = new SqlCommand("DeleteStaff", newConnection);
            newSqlCommand.CommandType = CommandType.StoredProcedure;
            newSqlCommand.Parameters.AddWithValue("@staffId", staffId);
            
            int result = newSqlCommand.ExecuteNonQuery();
            newConnection.Close();
            return result;
        }
    }
}