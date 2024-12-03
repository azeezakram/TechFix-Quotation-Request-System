using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UserService.DataAccess
{
    public class DataAccessLayer
    {
        public static SqlConnection OpenConnection()
        {
            string sqlConnectionString = @"Server=DESKTOP-T4AMH0P\SQLEXPRESS;Database=TechfixDB;Trusted_Connection=True;";
            SqlConnection myConnection = new SqlConnection(sqlConnectionString);
            return myConnection;
        }
    }
}




