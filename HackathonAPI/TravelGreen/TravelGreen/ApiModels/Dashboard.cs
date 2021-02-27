using System.Collections.Generic;

namespace TravelGreen.ApiModels
{
    public class Dashboard
    {
        public double AverageMonthlyFootprint { get; set; }

        //public double LastMonthAverage { get; set; } //does not have to be displayed

        public List<Summary> Summaries { get; set; }

        public string Insight { get; set; }
    }
}