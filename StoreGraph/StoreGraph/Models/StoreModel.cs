using System.Collections.Generic;
using System.Data;

namespace StoreGraph.Models
{
    public class StoreModel
    {
        public List<string> StoreIds { get; set; }
        public int SelectedStoreId { get; set; }
    }
}