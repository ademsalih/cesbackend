using System.Collections.Generic;
using TelstarLogistics.DataAccess.Classes;

namespace TLAPI.Services
{
    public interface IRoutesService
    {
        void addCustomer(string name, string password);
        List<City> GetCities();
    }
}