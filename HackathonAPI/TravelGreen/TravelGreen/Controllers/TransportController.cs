using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using TravelGreen.ApiModels;
using TravelGreen.Data;
using TravelGreen.Data.Enums;
using TravelGreen.Data.Models;

namespace TravelGreen.Controllers
{
    public class TransportController : ApiController
    {
        private TravelGreenDbContext db = new TravelGreenDbContext();

        // GET: api/Entries
        public IQueryable<Entry> GetEntries()
        {
            return db.Entries;
        }

        // GET api/values
        public Dashboard Get()
        {
            var dashboard = new Dashboard();
            dashboard.Last30DaysFootprint = db.Entries
                .Where(x => x.Date <= DateTime.Now.AddDays(-30))
                .Sum(x => x.Footprint);
            dashboard.Insight = "test";

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

            var summaries = new List<Summary>();
            foreach (var transportType in transportTypes)
            {
                var summary = new Summary()
                {
                    TransportType = transportType.ID,
                    Minutes = db.Entries
                        .Where(x => x.Date <= DateTime.Now.AddDays(-period))
                        .Sum(x => x.Minutes),
                    FootprintSum = db.Entries
                        .Where(x => x.Date <= DateTime.Now.AddDays(-period))
                        .Sum(x => x.Footprint)
                };
                if ((summary.Minutes != 0) || (summary.FootprintSum != 0))
                    summaries.Add(summary);
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
