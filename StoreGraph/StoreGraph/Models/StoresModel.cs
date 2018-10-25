using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StoreGraph.Models
{
    public class StoresModel
    {
        public static List<string> StoreIDs { get; set; }
        
        public static DataTable StoresDataTable { get; set; }

        public int SelectedStoreID { get; set; }
        public int SelectedStoreFloor { get; set; }
    }
}