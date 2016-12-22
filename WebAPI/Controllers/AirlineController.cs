using AirlineDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineBO;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/airline")]
    public class AirlineController : ApiController
    {
        [Route("getDetails")]
        public string GetAirlineDetails()
        {            
            DataTable dtAirlines = AirDAL.getAirlineDetails();
            return JsonConvert.SerializeObject(dtAirlines);
        }

        [Route("postDetails")]
        public string PostAirlineDetails(AirBO air)
        {
            AirDAL.createAirlineDetails(air);
            DataTable dtAirlines = AirDAL.getAirlineDetails();
            return JsonConvert.SerializeObject(dtAirlines);
        }
    }
}
