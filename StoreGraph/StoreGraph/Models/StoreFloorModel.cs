using System.Collections.Generic;

namespace StoreGraph.Models
{
    public static class StoreFloorModel
    {
        public static List<string> StoreFloors { get; set; }
    }

    public class StoreFloor
    {
        public string SelectedStoreFloor { get; set; }
    }
}