using StoreGraph.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StoreGraph.Data
{
    public static class StoreIDs
    {
        public static DataTable Get()
        {
            DbConnect.OpenConnection();

            SqlCommand cmd = DbConnect.ConnectionDatabase.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetStoreIDAndFloors";
            cmd.CommandTimeout = DbConnect.ConnectionTimeout;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);

            DbConnect.CloseConnection();

            return data;
        }

        public static void SetModel(DataTable dataTable)
        {
            StoresModel.StoreIDs = dataTable.Select().Select(id => id.ItemArray[0]).Select(id => id.ToString()).ToList(); // retrieve all possible store ids (returns with duplicates)
            StoresModel.StoreIDs = StoresModel.StoreIDs.GroupBy(x => x).Where(g => g.Count() > 0).Select(y => y.Key).ToList(); // remove duplicates from store ids
        }

        public static void SetStoreFloors(int storeID)
        {
            var storeModelData = dataTable.Select().Select(t => t.ItemArray).ToArray();

            for (int id = 0; id < StoresModel.StoreIDs.Count(); id++)
            {
                var row = storeModelData[id].ToArray();
                var storeID = row[0];

                if (storeID.ToString() == StoresModel.StoreIDs[id])
                {

                }
            }
        }
    }
}