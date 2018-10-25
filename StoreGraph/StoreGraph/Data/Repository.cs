using StoreGraph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreGraph.Data
{
    public static class Repository
    {
        public static StoreModel StoreModel { get; set; } = new StoreModel();
    }
}