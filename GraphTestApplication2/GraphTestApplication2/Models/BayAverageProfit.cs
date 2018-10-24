using System.Collections.Generic;

namespace GraphTestApplication2.Models
{
    public static class BayAverageProfit
    {
        public static List<string> BayID { get; set; } = new List<string>();
        public static List<string> BayProfit { get; set; } = new List<string>();

        public static bool AreListLengthsSame => BayID.Count == BayProfit.Count;
    }
}