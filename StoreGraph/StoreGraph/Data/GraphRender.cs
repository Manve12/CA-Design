﻿using StoreGraph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace StoreGraph.Data
{
    public static class GraphRender
    {
        public static byte[] RenderGraph(int chartWidth,
                                         int chartHeight,
                                         string chartTitle,
                                         string chartType,
                                         string graphTemplate,
                                         string[] _yValues,
                                         string[] _xValues,
                                         string xAxisTitle,
                                         string yAxisTitle
            )
        {
            byte[] newChart = new Chart(width: chartWidth,
                                           height: chartHeight,
                                           theme: graphTemplate)
                   .AddTitle(chartTitle)
                   .AddSeries(
                       chartType: chartType,
                       yValues: _yValues,
                       xValue: _xValues
                       )
                      .SetXAxis(min: 1, max: _xValues.Length, title: xAxisTitle)
                      .SetYAxis(title: yAxisTitle)
                   .GetBytes();

            return newChart;
        }

        public static byte[] RenderGraph(GraphModel model)
        {
            byte[] newChart = new Chart(width: model.Width,
                                           height: model.Height,
                                           theme: model.GraphTemplate)
                   .AddTitle(model.Title)
                   .AddSeries(
                       chartType: model.GraphType,
                       yValues: model.YAxisData,
                       xValue: model.XAxisData
                       )
                      .SetXAxis(min: 1, max: model.XAxisData.Length, title: model.XAxisTitle)
                      .SetYAxis(title: model.YAxisTitle)
                   .GetBytes();

            return newChart;
        }
    }
}