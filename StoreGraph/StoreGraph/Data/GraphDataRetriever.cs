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
            return GetData(StoreID, "sp_GetBayAverageProfitGraph", StoreFloor);
        }

        public static DataTable GetTotalSalesWeeks13(int StoreID)
        {
            return GetData(StoreID, "sp_GetTotalSalesWeeks13");
        }

        public static DataTable GetTotalSalesWeeks52(int StoreID)
        {
           return GetData(StoreID, "sp_GetTotalSalesWeeks52");
        }

        public static DataTable GetTotalVolumeWeeks13(int StoreID)
        {
            return GetData(StoreID,"sp_GetTotalVolumeWeeks13");
        }

        public static DataTable GetTotalVolumeWeeks52(int StoreID)
        {
            return GetData(StoreID,"sp_GetTotalVolumeWeeks52");
        }

        public static DataTable GetTotalVolumeAndSalesWeeks13(int StoreID)
        {
            return GetData(StoreID, "sp_GetTotalVolumeAndSalesWeeks13");
        }

        public static DataTable GetTotalVolumeAndSalesWeeks52(int StoreID)
        {
            return GetData(StoreID, "sp_GetTotalVolumeAndSalesWeeks52");
        }

        private static DataTable GetData(int StoreID, string StoredProcedureName, string StoreFloor = null)
        {
            DbConnect.OpenConnection();

            SqlCommand cmd = DbConnect.ConnectionDatabase.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = StoredProcedureName;
            cmd.Parameters.AddWithValue("@StoreID", StoreID);
            if (StoreFloor!=null)
            cmd.Parameters.AddWithValue("@StoreFloor", StoreFloor);
            cmd.CommandTimeout = DbConnect.ConnectionTimeout;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);

            DbConnect.CloseConnection();

            return data;
        }
    }
}