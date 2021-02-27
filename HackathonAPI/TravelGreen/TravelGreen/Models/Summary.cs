using TravelGreen.Data.Enums;

namespace TravelGreen.Models
{
    public class Summary
    {
        public TransportEnum Transport { get; set; }
        public int Minutes { get; set; }
        public double FootprintSum { get; set; }
    }
}