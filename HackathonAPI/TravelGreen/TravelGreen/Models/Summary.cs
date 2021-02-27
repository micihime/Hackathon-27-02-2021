using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelGreen.Models
{
    public class Summary
    {
        public TransportType Transport { get; set; }
        public int Minutes { get; set; }
        public double FootprintSum { get; set; }
    }
}