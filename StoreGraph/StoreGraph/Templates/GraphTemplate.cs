using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreGraph.Data
{
    public static class GraphTemplate
    {
        public static string graphTemplate = "<Chart>"+
                      "<ChartAreas>"+
                        "<ChartArea Name='Default' _Template_='All'>"+
                          "<AxisY>"+
                            "<LabelStyle Font='Verdana, 12px' Interval='10'/>"+
                          "</AxisY>"+
                          "<AxisX LineColor='64, 64, 64, 64' Interval='1'>"+
                            "<LabelStyle Font='Verdana, 40px' />"+
                          "</AxisX>"+
                        "</ChartArea>"+
                      "</ChartAreas>"+
                    "</Chart>";
    }
}