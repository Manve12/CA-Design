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

            return RenderGraph(model);
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

            return RenderGraph(model);
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

            return RenderGraph(model);
        }

        public ActionResult RenderTotalVolumeWeeks13(int SelectedStoreID)
        {
            var dataTable = GraphDataRetriever.GetTotalVolumeWeeks13(SelectedStoreID);

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
            model.YAxisTitle = "Total Volume";
            model.GraphType = "line";

            return RenderGraph(model);
        }

        public ActionResult RenderTotalVolumeWeeks52(int SelectedStoreID)
        {
            var dataTable = GraphDataRetriever.GetTotalVolumeWeeks52(SelectedStoreID);

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
            model.YAxisTitle = "Total Volume";
            model.GraphType = "line";

            return RenderGraph(model);
        }

        public ActionResult RenderTotalVolumeAndSalesWeeks13(int SelectedStoreID)
        {
            var dataTable = GraphDataRetriever.GetTotalVolumeAndSalesWeeks13(SelectedStoreID);

            TotalVolumeModel.TotalVolume = dataTable
                                            .Select()
                                            .Select(s => s.ItemArray[0])
                                            .Select(s => s.ToString())
                                            .ToList();

            TotalSalesModel.TotalSales = dataTable
                                            .Select()
                                            .Select(s => s.ItemArray[1])
                                            .Select(s => s.ToString())
                                            .ToList();

            var weekCounter = dataTable
                                            .Select()
                                            .Select(s => s.ItemArray[2])
                                            .Select(s => s.ToString())
                                            .ToList();

            TotalVolumeModel.WeekCounter = weekCounter;
            TotalSalesModel.WeekCounter = weekCounter;
            
            GraphModel model = new GraphModel();
            model.XAxisData = TotalVolumeModel.WeekCounter.ToArray();
            model.YAxisData = TotalVolumeModel.TotalVolume.ToArray();
            model.XAxisDataAdditional = TotalSalesModel.WeekCounter.ToArray();
            model.YAxisDataAdditional = TotalSalesModel.TotalSales.ToArray();

            model.Height = TotalSalesModel.TotalSales.ToArray().Length * 40;
            model.Width = TotalSalesModel.TotalSales.ToArray().Length * 60;
            model.GraphTemplate = GraphTemplate.graphTemplateInterval10;

            model.SeriesTitleInitial = "Volume";
            model.SeriesTitleAdditional = "Sales";

            model.XAxisTitle = "Weeks 13 Counter";
            model.YAxisTitle = "Total volume and sales";
            model.GraphType = "line";

            return RenderGraph(model);
        }

        public ActionResult RenderTotalVolumeAndSalesWeeks52(int SelectedStoreID)
        {
            var dataTable = GraphDataRetriever.GetTotalVolumeAndSalesWeeks52(SelectedStoreID);

            TotalVolumeModel.TotalVolume = dataTable
                                            .Select()
                                            .Select(s => s.ItemArray[0])
                                            .Select(s => s.ToString())
                                            .ToList();

            TotalSalesModel.TotalSales = dataTable
                                            .Select()
                                            .Select(s => s.ItemArray[1])
                                            .Select(s => s.ToString())
                                            .ToList();

            var weekCounter = dataTable
                                            .Select()
                                            .Select(s => s.ItemArray[2])
                                            .Select(s => s.ToString())
                                            .ToList();

            TotalVolumeModel.WeekCounter = weekCounter;
            TotalSalesModel.WeekCounter = weekCounter;

            GraphModel model = new GraphModel();
            model.XAxisData = TotalVolumeModel.WeekCounter.ToArray();
            model.YAxisData = TotalVolumeModel.TotalVolume.ToArray();
            model.XAxisDataAdditional = TotalSalesModel.WeekCounter.ToArray();
            model.YAxisDataAdditional = TotalSalesModel.TotalSales.ToArray();

            model.Height = TotalSalesModel.TotalSales.ToArray().Length * 40;
            model.Width = TotalSalesModel.TotalSales.ToArray().Length * 60;
            model.GraphTemplate = GraphTemplate.graphTemplateInterval100;

            model.SeriesTitleInitial = "Volume";
            model.SeriesTitleAdditional = "Sales";

            model.XAxisTitle = "Weeks 52 Counter";
            model.YAxisTitle = "Total volume and sales";
            model.GraphType = "line";

            return RenderGraph(model);
        }


        private ActionResult RenderGraph(GraphModel model)
        {
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