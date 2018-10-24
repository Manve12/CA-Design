using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GraphTestApplication2.Data
{
    public static class AverageProfit
    {
        public static DataTable getAverageProfit(AverageProfitWeek _averageProfit)
        {
            DbConnection.OpenConnection(); 
             
            SqlCommand cmd = DbConnection.ConnectionDatabase.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            if (_averageProfit == AverageProfitWeek.sp_AverageProfitWeek13)
            {
                cmd.CommandText = "sp_AverageProfitWeek13";
            } else
            {
                cmd.CommandText = "sp_AverageProfitWeek52";
            }
            cmd.CommandTimeout = DbConnection.ConnectionTimeout;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);

            DbConnection.CloseConnection();

            return data;
        }
    }
}