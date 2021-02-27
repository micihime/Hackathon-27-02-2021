using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TravelGreen.ApiModels;
using TravelGreen.Data;
using TravelGreen.Data.Models;

namespace TravelGreen.Controllers
{
    public class EntriesController : ApiController
    {
        private TravelGreenDbContext db = new TravelGreenDbContext();

        // GET: api/Entries
        public Dashboard Get()
        {
            DateTime date = DateTime.Now.AddDays(-30);

            var entries = db.Entries.Where(x => x.Date <= date).ToList();
                
            var dashboard = new Dashboard();

            dashboard.Last30DaysFootprint = entries.Sum(x => x.Footprint);
            dashboard.Insight = "Dnes sa ti podarilo zachrániť 1 strom!";

            return dashboard;
        }

        // GET: api/Entries/5
        [ResponseType(typeof(Entry))]
        public IHttpActionResult GetEntry(int id)
        {
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        // PUT: api/Entries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntry(int id, Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entry.ID)
            {
                return BadRequest();
            }

            db.Entry(entry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Entries
        [ResponseType(typeof(Entry))]
        public IHttpActionResult PostEntry(Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entries.Add(entry);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = entry.ID }, entry);
        }

        // DELETE: api/Entries/5
        [ResponseType(typeof(Entry))]
        public IHttpActionResult DeleteEntry(int id)
        {
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return NotFound();
            }

            db.Entries.Remove(entry);
            db.SaveChanges();

            return Ok(entry);
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