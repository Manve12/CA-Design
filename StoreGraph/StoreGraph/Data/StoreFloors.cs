using StoreGraph.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StoreGraph.Data
{
    public static class StoreFloors
    {
        public static DataTable Get(int SelectedStoreID)
        {
            DbConnect.OpenConnection();

            SqlCommand cmd = DbConnect.ConnectionDatabase.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetStoreFloors";
            cmd.Parameters.AddWithValue("@StoreID", SelectedStoreID);
            cmd.CommandTimeout = DbConnect.ConnectionTimeout;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);

            DbConnect.CloseConnection();

            return data;
        }

        public static void SetModel(DataTable dataTable)
        {
            StoresModel.StoreFloors = dataTable.Select().Select(id => id.ItemArray[0]).Select(id => id.ToString()).ToList();
        }
    }
}