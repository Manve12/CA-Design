using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StoreGraph.Data
{
    public static class GraphDataRetriever
    {
        public static DataTable GetBayAverageProfitGraph(int StoreID)
        {
            DbConnect.OpenConnection();

            SqlCommand cmd = DbConnect.ConnectionDatabase.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetBayAverageProfitGraph";
            cmd.Parameters.AddWithValue("@StoreID", StoreID);
            cmd.CommandTimeout = DbConnect.ConnectionTimeout;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);
            
            DbConnect.CloseConnection();

            return data;
        }
    }
}