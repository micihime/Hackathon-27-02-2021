using System.Collections.Generic;
using System.Web.Http;
using TravelGreen.Data.Enums;
using TravelGreen.ApiModels;

namespace TravelGreen.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public Dashboard GetDashboard()
        //{
        //    var dashboard = new Dashboard()
        //    {
        //        AverageMonthlyFootprint = 100,
        //        Summaries = new List<Summary>()
        //        {
        //            new Summary { Transport = TransportEnum.Car, Minutes = 1500, FootprintSum = 169},
        //            new Summary { Transport = TransportEnum.Bus, Minutes = 237, FootprintSum = 24}
        //        },
        //        Insight = "Hlaska porovnanie oproti min mesiacu"
        //    };
        //    return dashboard;
        //}

        //// GET api/values/5
        //public List<Summary> Get(int id)
        //{
        //    //call method that computes summary from specified time period
        //    var summaries = new List<Summary>()
        //            {
        //                new Summary { Transport = TransportEnum.Car, Minutes = 1500, FootprintSum = 169},
        //                new Summary { Transport = TransportEnum.Bus, Minutes = 237, FootprintSum = 24}
        //        };
        //    return summaries;
        //}

        // GET api/values/5
        [HttpPost]
        public IHttpActionResult Post([FromBody] Data.Models.Entry entry)
        {
            if (entry == null)
                return BadRequest("Entry null.");
            else
                //save
                return Ok();
        }
    }
}