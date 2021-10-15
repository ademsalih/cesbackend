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
using TelstarLogistics.Services;
using TLAPI.Models;
using TLAPI.Services;

//using TelstarLogistics.Models;
//using TelstarLogistics.Services;

namespace TelstarLogistics.Controllers
{
    [RoutePrefix("routes")]
    public class RoutesController : ApiController
    {
        private readonly IRoutesService _routesService;
        public RoutesController()
        {
            TelstarLogisticsContext dbContext = new TelstarLogisticsContext();
            _routesService = new RoutesService(dbContext);
        }

        [Route("createEmployee")]
        public string CreateEmployee(string name,string password)
        {
            ExternalSystemsService externalSystemsService = new ExternalSystemsService();
            //rs.addCustomer(name,password);
            using (var db = new TelstarLogisticsContext())
            {
              var person=  db.Persons.FirstOrDefault(x => x.Name.Equals(name));
              return person.Name;
            }
        }

        //[Route("findRoutes")]
        //public FindRouteResponse Route(FindRouteRequest request)
        //{
        //    return new FindRouteResponse
        //    {
        //        Cost = 45.2,
        //        Time =11.3,
        //        CityTo = request.CityTo,
        //        CityFrom = request.CityFrom
        //    };
        //}

        //[Route("findCheapestRoute")]
        //public FindRouteResponse CheapestRoute(FindRouteRequest request)
        //{
        //    return new FindRouteResponse
        //    {
        //        Cost = 20.2,
        //        Time = 15.3,
        //        CityTo = request.CityTo,
        //        CityFrom = request.CityFrom
        //    };
        //}

        [Route("findShortestRoute")]
        public FindRouteResponse ShortestRoute(FindRouteRequest request)
        {
            int distance = 0;
            try
            {
               PathFinder pf = new PathFinder();
               distance = pf.GetDistance(pf.MapNameToId(request.CityFrom), pf.MapNameToId(request.CityTo));
            }
            catch(Exception ex)
            {
                return new FindRouteResponse
                {
                    Cost = 0,
                    Time = 0,
                    CityTo = request.CityTo,
                    CityFrom = request.CityFrom
                };
            }

            return new FindRouteResponse
            {
                Cost = distance*3,
                Time = distance*4,
                CityTo = request.CityTo,
                CityFrom = request.CityFrom
            };
        }

        [Route("postOrder")]
        [HttpPost]
        public Order PlaceOrder(MakeAnOrderRequest request)
        {
            return _routesService.SaveOrder(request); ;
        }

        [Route("getCities")]
        public List<City> GetCities()
        {
            var cities = _routesService.GetCities();
            return cities;
        }

    }
}