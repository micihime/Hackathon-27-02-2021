using System.Collections.Generic;
using System.Web.Http;
using TravelGreen.Data.Enums;
using TravelGreen.ApiModels;
using TravelGreen.Data;
using System.Linq;
using System;
using TravelGreen.Data.Models;

namespace TravelGreen.Controllers
{
    public class ValuesController : ApiController
    {
        private TravelGreenDbContext db = new TravelGreenDbContext();

        // GET: api/Entries
        public IQueryable<Entry> GetEntries()
        {
            return db.Entries;
        }

        public Dashboard Get()
        {
            DateTime date = DateTime.Now.AddDays(-30);
            var dashboard = new Dashboard();
            dashboard.Last30DaysFootprint = db.Entries
                .Where(x => x.Date <= date)
                .Sum(x => x.Footprint);
            dashboard.Insight = "Dnes sa ti podarilo zachrániť 1 strom!";

            return dashboard;
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