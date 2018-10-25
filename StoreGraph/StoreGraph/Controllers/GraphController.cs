using StoreGraph.Data;
using StoreGraph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreGraph.Controllers
{
    public class GraphController : Controller
    {
        public ActionResult RenderProfitsPerBay(int SelectedStoreID, string SelectedStoreFloor)
        {
            var dataTable = GraphDataRetriever.GetBayAverageProfit(SelectedStoreID,SelectedStoreFloor);

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

            GraphModel model = new GraphModel();
            model.XAxisData = AverageBayProfitModel.Bay.ToArray();
            model.YAxisData = AverageBayProfitModel.AverageProfitWeeks13.ToArray();
            model.XAxisTitle = "Bay number";
            model.YAxisTitle = "Average Profit";
            model.Title = "Average profit per bay";

            var newChart = GraphRender.RenderGraph(model);

            string imageBase64Data = Convert.ToBase64String(newChart);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            if (imageDataURL.Length > 0)
            {
                ViewBag.ImageUrl = imageDataURL;
            }

            return View("~/Views/Home/RenderGraph.cshtml");
        }

        public ActionResult RenderTotalSalesWeeks13(int SelectedStoreID)
        {
            var dataTable = GraphDataRetriever.GetTotalSalesWeeks13(SelectedStoreID);

            TotalSalesModel.TotalSales = dataTable
                                            .Select()
                                            .Select(s => s.ItemArray[0]) 
                                            .Select(s => s.ToString())
                                            .ToList();

            TotalSalesModel.WeekCounter = dataTable
                                            .Select()
                                            .Select(s => s.ItemArray[1])
                                            .Select(s => s.ToString())
                                            .ToList();
            
            GraphModel model = new GraphModel();
            model.XAxisData = TotalSalesModel.WeekCounter.ToArray();
            model.YAxisData = TotalSalesModel.TotalSales.ToArray();
            model.Height = TotalSalesModel.TotalSales.ToArray().Length * 40;
            model.Width = TotalSalesModel.TotalSales.ToArray().Length * 60;
            model.XAxisTitle = "Weeks 13 Counter";
            model.YAxisTitle = "Total Sales";
            model.GraphType = "line";
            

            var newChart = GraphRender.RenderGraph(model);

            string imageBase64Data = Convert.ToBase64String(newChart);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            if (imageDataURL.Length > 0)
            {
                ViewBag.ImageUrl = imageDataURL;
            }

            return View("~/Views/Home/RenderGraph.cshtml");
        }

        public ActionResult RenderTotalSalesWeeks52(int SelectedStoreID)
        {
            var dataTable = GraphDataRetriever.GetTotalSalesWeeks52(SelectedStoreID);

            TotalSalesModel.TotalSales = dataTable
                                            .Select()
                                            .Select(s => s.ItemArray[0])
                                            .Select(s => s.ToString())
                                            .ToList();

            TotalSalesModel.WeekCounter = dataTable
                                            .Select()
                                            .Select(s => s.ItemArray[1])
                                            .Select(s => s.ToString())
                                            .ToList();

            GraphModel model = new GraphModel();
            model.XAxisData = TotalSalesModel.WeekCounter.ToArray();
            model.YAxisData = TotalSalesModel.TotalSales.ToArray();
            model.Height = TotalSalesModel.TotalSales.ToArray().Length * 40;
            model.Width = TotalSalesModel.TotalSales.ToArray().Length * 60;
            model.GraphTemplate = GraphTemplate.graphTemplateInterval100;
            model.XAxisTitle = "Weeks 52 Counter";
            model.YAxisTitle = "Total Sales";
            model.GraphType = "line";


            var newChart = GraphRender.RenderGraph(model);

            string imageBase64Data = Convert.ToBase64String(newChart);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            if (imageDataURL.Length > 0)
            {
                ViewBag.ImageUrl = imageDataURL;
            }

            return View("~/Views/Home/RenderGraph.cshtml");
        }
    }
}