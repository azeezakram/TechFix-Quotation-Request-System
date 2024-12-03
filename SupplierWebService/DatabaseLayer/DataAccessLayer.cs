using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentWebServiceApp.databaseLayer
{
    public static class DataAccessLayer
    {
        public static SqlConnection OpenConnection()
        {
            string myConnectionString = @"Server=DESKTOP-T4AMH0P\SQLEXPRESS;Database=TechfixDB;Trusted_Connection=True";
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            return myConnection;
        }
    }
}