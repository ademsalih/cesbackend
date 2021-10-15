using System.Collections.Generic;
using TelstarLogistics.DataAccess.Classes;
using TLAPI.Models;

namespace TLAPI.Services
{  
    public interface IRoutesService
    {
        List<City> GetCities();
        void PopulateCities(string cities);
        Order SaveOrder(MakeAnOrderRequest request);
    }
}