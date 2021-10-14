using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using TelstarLogistics.DataAccess;
using TelstarLogistics.DataAccess.Classes;
using TelstarLogistics.Models;
using TLAPI.Services;

//using TelstarLogistics.Models;
//using TelstarLogistics.Services;

namespace TelstarLogistics.Controllers
{
    [RoutePrefix("routes")]
    public class RoutesController : ApiController
    {
        private RoutesService routesService;
        RoutesController()
        {
            RoutesService routesService = new RoutesService();
        }

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

        [Route("findCheapestRoute")]
        public FindRouteResponse CheapestRoute(FindRouteRequest request)
        {
            return new FindRouteResponse
            {
                Cost = 20.2,
                Time = 15.3,
                CityTo = request.CityTo,
                CityFrom = request.CityFrom
            };
        }

        [Route("findShortestRoute")]
        public FindRouteResponse ShortestRoute(FindRouteRequest request)
        {
            return new FindRouteResponse
            {
                Cost = 45.2,
                Time = 11.3,
                CityTo = request.CityTo,
                CityFrom = request.CityFrom
            };
        }

        [Route("order")]
        [HttpPost]
        public string PlaceOrder(int id, string backendOnly)
        {
            return $@"{id}{backendOnly}";
        }

        [Route("getCities")]
        public List<City> GetCities()
        {
            var cities = routesService.GetCities();

            return cities;
        }
    }
}