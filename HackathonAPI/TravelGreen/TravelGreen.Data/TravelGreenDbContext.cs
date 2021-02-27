using System.Data.Entity;
using TravelGreen.Data.Models;

namespace TravelGreen.Data
{
    public class TravelGreenDbContext : DbContext
    {
        public TravelGreenDbContext()
            : base("default")
        {
        }

        public virtual DbSet<TransportFootprintValue> TransportFootprintValues { get; set; }
        public virtual DbSet<TransportType> TransportTypes { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
    }
}
