using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Logging;
using TelstarLogistics.Models;
using TelstarLogistics.Services;

namespace TelstarLogistics.Controllers
{
    [RoutePrefix("v1/Routes")]
    public class RoutesController : ApiController
    {
        // GET api/<controller>/get
        public string GetIt()
        {
           ExternalSystemsService ess = new ExternalSystemsService();
           var data= ess.getRoutes("http://wa-tl-t1.azurewebsites.net/api/routes");
           return data;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return id.ToString();

        }

        // GET api/<controller>/
        [Route("findRoutes")]
        [HttpGet()]
        public FindRouteResponse GetRoute([FromBody]FindRouteRequest request)
        {
            return new FindRouteResponse
            {
                Cost = 45.2,
                Time =11.3,
                CityTo = request.CityTo,
                CityFrom = request.CityFrom

            };

        }

        [Route("details")]
        [HttpGet()]
        public string Details(int id, string backendOnly)
        {
            return $@"{id}{backendOnly}";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }


       
    }
}