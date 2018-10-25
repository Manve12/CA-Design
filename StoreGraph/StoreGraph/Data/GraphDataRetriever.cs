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
        public static DataTable GetBayAverageProfit(int StoreID, string StoreFloor)
        {
            DbConnect.OpenConnection();

            SqlCommand cmd = DbConnect.ConnectionDatabase.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetBayAverageProfitGraph";
            cmd.Parameters.AddWithValue("@StoreID", StoreID);
            cmd.Parameters.AddWithValue("@StoreFloor", StoreFloor);
            cmd.CommandTimeout = DbConnect.ConnectionTimeout;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);
            
            DbConnect.CloseConnection();

            return data;
        }

        private static DataTable GetTotal(int StoreID, string StoredProcedureName)
        {
            DbConnect.OpenConnection();

            SqlCommand cmd = DbConnect.ConnectionDatabase.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = StoredProcedureName;
            cmd.Parameters.AddWithValue("@StoreID", StoreID);
            cmd.CommandTimeout = DbConnect.ConnectionTimeout;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);

            DbConnect.CloseConnection();

            return data;
        }

        public static DataTable GetTotalSalesWeeks13(int StoreID)
        {
            return GetTotal(StoreID, "sp_GetTotalSalesWeeks13");
        }

        public static DataTable GetTotalSalesWeeks52(int StoreID)
        {
           return GetTotal(StoreID, "sp_GetTotalSalesWeeks52");
        }

        public static DataTable GetTotalVolumeWeeks13(int StoreID)
        {
            return GetTotal(StoreID,"sp_GetTotalVolumeWeeks13");
        }

        public static DataTable GetTotalVolumeWeeks52(int StoreID)
        {
            return GetTotal(StoreID,"sp_GetTotalVolumeWeeks52");
        }
    }
}