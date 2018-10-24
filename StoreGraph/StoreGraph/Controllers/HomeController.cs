using StoreGraph.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            
            return View();
        }
    }
}