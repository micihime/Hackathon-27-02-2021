﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelGreen.Models
{
    public class Entry
    {
        public long ID { get; set; }
        public TransportType Transport { get; set; }
        public int Minutes { get; set; }
    }
}