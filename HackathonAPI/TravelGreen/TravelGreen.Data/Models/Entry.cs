using System;

namespace TravelGreen.Data.Models
{
    public class Entry
    {
        public int ID { get; set; }
        
        public DateTime Date { get; set; }

        public TransportType Transport { get; set; }

        public int Minutes { get; set; }
    }
}