using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelstarLogistics.DataAccess;
using TelstarLogistics.DataAccess.Classes;

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
    }
}