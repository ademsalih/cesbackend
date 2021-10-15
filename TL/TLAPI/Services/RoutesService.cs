using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelstarLogistics.DataAccess;
using TelstarLogistics.DataAccess.Classes;
using TLAPI.Models;

namespace TLAPI.Services
{
    public class RoutesService : IRoutesService
    {
        private readonly TelstarLogisticsContext _dbContext;

        public RoutesService(TelstarLogisticsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<City> GetCities()
        {
            
            var cities = _dbContext.Cities.ToList();

            return cities;
            
        }

        public void PopulateCities(string cities)
        {

          var eachCityAndId = cities.Split(';');

          foreach (var cityAndid in eachCityAndId)
          {

              var abd = cityAndid.Split(',');
              _dbContext.Cities.Add(new City()
              {
                  DisplayName = abd[0],
                  Id = Int32.Parse(abd[1]),
                  Name = abd[0]
              });
              _dbContext.SaveChanges();
          }


        }

        public Order SaveOrder(MakeAnOrderRequest request)
        {
            var newOrder = new Order()
            {
                CityFrom = request.CityFrom,
                CityTo = request.CityTo,
                Cost = request.Price,
                CustomerId = request.CustomerId,
                Duration = request.Duration,
                RouteSegmentId = request.RouteSegmentId,
                ShippingStatus = true
            };

            _dbContext.Orders.Add(newOrder);

            _dbContext.SaveChanges();
            return newOrder;
        }

    }
}