using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelGreen.Models
{
    public class Dashboard
    {
        public double AverageMonthlyFootprint { get; set; }

        public double LastMonthAverage { get; set; }

        public List<Summary> Summaries { get; set; }

        public string Insight { get; set; }
    }
}