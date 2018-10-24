﻿namespace StoreGraph.Models
{
    public class GraphModel
    {
        public int Width { get; set; } = 600;
        public int Height { get; set; } = 400;

        public string Title { get; set; }

        public string GraphType { get; set; } = "column";

        public string GraphTemplate { get; set; } = Data.GraphTemplate.graphTemplate;

        public string[] XAxisData { get; set; }
        public string[] YAxisData { get; set; }

        public string XAxisTitle { get; set; }
        public string YAxisTitle { get; set; }
    }
}