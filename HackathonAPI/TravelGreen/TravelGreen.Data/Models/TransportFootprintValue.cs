namespace TravelGreen.Data.Models
{
    public class TransportFootprintValue
    {
        public int ID { get; set; }

        public TransportType TransportType { get; set; }

        public int FootprintPerKm { get; set; }

        public int FootprintPerMin { get; set; }
    }
}
