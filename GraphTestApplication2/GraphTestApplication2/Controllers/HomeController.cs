using GraphTestApplication2.Data;
using GraphTestApplication2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace GraphTestApplication2.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var chart = GetChart();
            if (chart != null)
            {
                string imageBase64Data = Convert.ToBase64String(chart);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                if (imageDataURL.Length > 0)
                {
                    ViewBag.ImageData = imageDataURL;
                }
            }
            return View();
        }

        public byte[] GetChart()
        {
            var t = GetBayGraph.getGraphByBay(1, "first");
            if (t != null)
            {
                byte[] newChart = new Chart(width: 900, height: 400)
                .AddTitle("BAY WEEK 13 PROFIT")
                .AddSeries(
                    chartType: "column",
                    yValues: BayAverageProfit.BayID.ToArray(),
                    xValue: BayAverageProfit.BayProfit.ToArray()
                    )
                .GetBytes();

                    return newChart;


            }
            return null;
        }

        public byte[] GetAverageWeek13Chart()
        {
            var t = AverageProfit.getAverageProfit(AverageProfitWeek.sp_AverageProfitWeek13).Columns["AverageProfitWeeks13"];
            if (t != null)
            {
                List<string> averageProfits = new List<string>();

                foreach (DataRow item in t.Table.Rows)
                {
                    averageProfits.Add(item.ItemArray[0].ToString());
                }

                byte[] newChart = new Chart(width: 900, height: 400)
                .AddTitle("Average Profit")
                .DataBindTable(dataSource: averageProfits.ToArray(), xField: "Average profit")
                .AddSeries("", chartType: "BoxPlot")
                .GetBytes();

                return newChart;
            }
            return null;
        }
    }
}