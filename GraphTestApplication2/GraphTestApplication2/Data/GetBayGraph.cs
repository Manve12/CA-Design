using GraphTestApplication2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GraphTestApplication2.Data
{
    public static class GetBayGraph
    {
        //public static DataTable getGraphByBay(int storeID, string floorName)
        //{
        //    DbConnection.OpenConnection();

        //    SqlCommand cmd = DbConnection.ConnectionDatabase.CreateCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "sp_TotalProfitPerBayWeeks13";
        //    cmd.Parameters.AddWithValue("@StoreID",storeID);
        //    cmd.Parameters.AddWithValue("@FloorName",floorName);
        //    cmd.CommandTimeout = DbConnection.ConnectionTimeout;

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable data = new DataTable();
        //    da.Fill(data);

        //    DbConnection.CloseConnection();

        //    return data;
        //}

        public static DataTable getGraphByBay(int storeID, string floorName)
        {
            DbConnection.OpenConnection();

            SqlCommand cmd = DbConnection.ConnectionDatabase.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_Week13GetAverageProfitPerBay";
            cmd.Parameters.AddWithValue("@StoreID", storeID);
            cmd.Parameters.AddWithValue("@FloorName", floorName);
            cmd.CommandTimeout = DbConnection.ConnectionTimeout;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);

            BayAverageProfit.BayID = data.Select().Select(s => s.ItemArray[0]).Select(s => s.ToString()).ToList();
            BayAverageProfit.BayProfit = data.Select().Select(s => s.ItemArray[1]).Select(s => s.ToString()).ToList();

            DbConnection.CloseConnection();

            return data;
        }
    }
}