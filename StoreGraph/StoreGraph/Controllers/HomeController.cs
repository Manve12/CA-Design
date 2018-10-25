﻿using StoreGraph.Data;
using StoreGraph.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            StoreIDs.SetModel(StoreIDs.Get()); // retrieve the store ids and store them in the model
            
            ViewBag.StoreIDs = StoreIDModel.StoreIDs;
            
            return View();
        }

        public ActionResult RenderGraph(int SelectedStoreID)
        {
            var dataTable = GraphDataRetriever.GetBayAverageProfitGraph(SelectedStoreID);

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
            return View();
        }
    }
}