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
        public Dashboard GetDashboard()
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
            //call method that computes summary from specified time period
            var summaries = new List<Summary>()
                //    {
                //        new Summary { Transport = TransportEnum.Car, Minutes = 1500, FootprintSum = 169},
                //        new Summary { Transport = TransportEnum.Bus, Minutes = 237, FootprintSum = 24}
                //}
            ;
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

            var dbEntry = new Entry()
            {
                Date = entry.Date,
                Minutes = entry.Minutes,
                TransportTypeId = entry.TransportType
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
