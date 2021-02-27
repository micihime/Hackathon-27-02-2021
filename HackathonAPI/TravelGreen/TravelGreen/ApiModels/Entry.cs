using System;

namespace TravelGreen.ApiModels
{
    public class Entry
    {
        //public long ID { get; set; }
        public DateTime Date { get; set; }

        public TransportType Transport { get; set; }

        public int Minutes { get; set; }
    }
}