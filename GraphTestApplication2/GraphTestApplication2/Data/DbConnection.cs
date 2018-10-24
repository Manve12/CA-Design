using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GraphTestApplication2.Data
{
    public static class DbConnection
    {
        public static string ConnectionString { get; } = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static SqlConnection ConnectionDatabase { get; set; } = new SqlConnection(ConnectionString);

        public static int ConnectionTimeout = 60;

        public static void OpenConnection()
        {
            ConnectionDatabase.Open();
        }

        public static void CloseConnection()
        {
            ConnectionDatabase.Close();
        }
    }
}