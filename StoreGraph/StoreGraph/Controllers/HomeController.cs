using StoreGraph.Data;
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
            StoreIDs.SetModel(StoreIDs.Get());

            ViewBag.StoreIDs = StoresModel.StoreIds;

            return View();
        }

        public ActionResult SelectStore(int SelectedStoreId)
        {
            StoreFloors.SetModel(StoreFloors.Get(SelectedStoreId));

            ViewBag.SelectedStoreId = SelectedStoreId;
            ViewBag.StoreFloors = StoresModel.StoreFloors;

            return View();
        }

        public ActionResult SelectFloor(int SelectedStoreId, string SelectedStoreFloor)
        {
            ViewBag.SelectedStoreId = SelectedStoreId;
            ViewBag.SelectedStoreFloor = SelectedStoreFloor;

            return View();
        }
    }
}