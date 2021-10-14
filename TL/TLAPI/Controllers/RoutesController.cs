using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using TelstarLogistics.DAL;
using TelstarLogistics.DAL.Classes;
using TelstarLogistics.Models;
using TLAPI.Services;

//using TelstarLogistics.Models;
//using TelstarLogistics.Services;

namespace TelstarLogistics.Controllers
{
    [RoutePrefix("v1/Routes")]
    public class RoutesController : ApiController
    {
        // GET api/<controller>/get
        //public string GetIt()
        //{
        //   var data= ess.getRoutes("http://wa-tl-t1.azurewebsites.net/api/routes");
        //   return data;
        //}

        // GET api/<controller>/5
        [Route("createEmployee")]
        public string CreateEmployee(string name,string password)
        {
            RoutesService rs = new RoutesService();
            rs.addCustomer(name,password);
            using (var db = new TelstarLogisticsContext())
            {
              var person=  db.Persons.FirstOrDefault(x => x.Name.Equals(name));
              return person.Name;
            }


        }

        // GET api/<controller>/
        [Route("findRoutes")]
        public FindRouteResponse Route(FindRouteRequest request)
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