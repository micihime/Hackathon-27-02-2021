using System;

namespace TravelGreen.ApiModels
{
    public class ApiEntry //POST
    {
        //public long ID { get; set; }
        public DateTime Date { get; set; }

        public int TransportType { get; set; }

        public int Minutes { get; set; }
    }
}