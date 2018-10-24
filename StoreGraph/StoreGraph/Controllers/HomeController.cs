using StoreGraph.Data;
using StoreGraph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace StoreGraph.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenderGraph()
        {
            var dataTable = GraphDataRetriever.GetBayAverageProfitGraph(1);

            AverageBayProfitModel.AverageProfitWeeks13 = dataTable
                                            .Select()
                                            .Select(s => s.ItemArray[0]) // selects the first instance (average profits weeks 13)
                                            .Select(s => s.ToString())
                                            .ToList();

            AverageBayProfitModel.AverageProfitWeeks52 = dataTable
                                            .Select()
                                            .Select(s => s.ItemArray[1]) // selects the second instance (average profits weeks 52)
                                            .Select(s => s.ToString())
                                            .ToList();

            AverageBayProfitModel.Bay = dataTable
                                            .Select()
                                            .Select(s => s.ItemArray[2]) // selects the third instance (bay)
                                            .Select(s => s.ToString())
                                            .ToList();

            string temp = @"<Chart>
                      <ChartAreas>
                        <ChartArea Name=""Default"" _Template_=""All"">
                          <AxisY>
                            <LabelStyle Font=""Verdana, 12px"" Interval=""1""/>
                          </AxisY>
                          <AxisX LineColor=""64, 64, 64, 64"" Interval=""1"">
                            <LabelStyle Font=""Verdana, 12px"" />
                          </AxisX>
                        </ChartArea>
                      </ChartAreas>
                    </Chart>";
            
            byte[] newChart = new Chart(width: 50 * AverageBayProfitModel.Bay.Count, height: 30 * AverageBayProfitModel.AverageProfitWeeks13.Count, theme:temp)
                .AddTitle("BAY WEEK 13 PROFIT")
                .AddSeries(
                    name: "baySeries",
                    chartType: "column",
                    yValues: AverageBayProfitModel.AverageProfitWeeks13.ToArray(),
                    xValue: AverageBayProfitModel.Bay.ToArray()
                    )
                   .SetXAxis(min: 1, max: AverageBayProfitModel.Bay.Count, title: "Bay Numbers")
                .GetBytes();

            string imageBase64Data = Convert.ToBase64String(newChart);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            if (imageDataURL.Length > 0)
            {
                ViewBag.ImageUrl = imageDataURL;
            }
            return View();
        }
    }
}