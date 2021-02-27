using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using TravelGreen.ApiModels;
using TravelGreen.Data;
using TravelGreen.Data.Models;

namespace TravelGreen.Controllers
{
    public class TransportController : ApiController
    {
        private TravelGreenDbContext db = new TravelGreenDbContext();

        // GET api/values
        public Dashboard Get()
        {
            DateTime date = DateTime.Now.AddDays(-30);

            var entries = db.Entries.Where(x => x.Date <= date).ToList();
            var dashboard = new Dashboard();
            if ((entries != null) || (entries.Count > 0))
            {
                dashboard.Last30DaysFootprint = entries.Sum(x => x.Footprint);
                dashboard.Insight = "Dnes sa ti podarilo zachrániť 1 strom!";
            }
            return dashboard;
        }

        // GET api/values/5
        public List<Summary> Get(int id)
        {
            int period;
            switch (id)
            {
                case 2: period = 7; break;
                case 3: period = 30; break;
                case 4: period = 365; break;
                default: period = 1; break;
            }

            var transportTypes = db.TransportTypes;
            DateTime date = DateTime.Now.AddDays(-period);
            var summaries = new List<Summary>();
            
            foreach (var transportType in transportTypes)
            {
                var entries = db.Entries.Where(x => x.TransportTypeId == transportType.ID).ToList();
                if ((entries != null) || (entries.Count > 0))
                {
                    var footprint = entries
                            .Where(x => x.Date <= date)
                            .Sum(x => x.Footprint);
                    var minutes = entries
                                .Where(x => x.Date <= date)
                                .Sum(x => x.Minutes);

                    var summary = new Summary()
                    {
                        TransportType = transportType.ID,
                        Minutes = minutes,
                        FootprintSum = footprint
                    };

                    summaries.Add(summary);
                }
            };
            
            return summaries;
        }

        // POST: api/Entries
        [ResponseType(typeof(ApiEntry))]
        public IHttpActionResult PostEntry(ApiEntry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var transportType = db.TransportTypes.Where(x => x.ID == entry.TransportType).FirstOrDefault();
            var footprintValue = db.TransportFootprintValues.Where(x => x.TransportTypeId == entry.TransportType).FirstOrDefault();
            if (footprintValue == null)
            {
                return BadRequest("Transport type not found.");
            }

            var dbEntry = new Entry()
            {
                Date = entry.Date,
                Minutes = entry.Minutes,
                TransportTypeId = entry.TransportType,
                Footprint = entry.Minutes * footprintValue.FootprintPerMin
            };

            db.Entries.Add(dbEntry);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dbEntry.ID }, entry);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntryExists(int id)
        {
            return db.Entries.Count(e => e.ID == id) > 0;
        }
    }
}
