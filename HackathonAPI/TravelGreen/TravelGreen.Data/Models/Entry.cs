using System;
using System.ComponentModel.DataAnnotations;

namespace TravelGreen.Data.Models
{
    public class Entry
    {
        [Key]
        public int ID { get; set; }
        
        public DateTime Date { get; set; }

        public TransportType Transport { get; set; }

        public int Minutes { get; set; }
    }
}