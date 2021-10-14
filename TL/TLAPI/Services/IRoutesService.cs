using System.Collections.Generic;
using TelstarLogistics.DataAccess.Classes;
using TelstarLogistics.Requests;

namespace TLAPI.Services
{  
    public interface IRoutesService
    {
        List<City> GetCities();
    }
}