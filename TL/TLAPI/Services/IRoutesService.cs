using System.Collections.Generic;
using TelstarLogistics.DataAccess.Classes;

namespace TLAPI.Services
{  
    public interface IRoutesService
    {
        List<City> GetCities();
        void PopulateCities(string cities);
    }
}