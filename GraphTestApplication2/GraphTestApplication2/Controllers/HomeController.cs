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
            string imageBase64Data = Convert.ToBase64String(GetChart());
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            if (imageDataURL.Length > 0)
            {
                ViewBag.ImageData = imageDataURL;
            }
            
            return View();
        }

        public byte[] GetChart()
        {
            byte[] newChart = new Chart(width: 600, height: 400)
            .AddTitle("Chart Title")
            .AddSeries(
                name: "Employee",
                xValue: new[] { "Jeffrey", "Andrew", "Julie", "Mary", "Dave" },
                yValues: new[] { "2", "6", "4", "5", "3" })
            .GetBytes();

            return newChart;
        }
    }
}