using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelstarLogistics.DataAccess;
using TelstarLogistics.DataAccess.Classes;

namespace TLAPI.Services
{
    public class RoutesService
    {

        public void addCustomer(string name, string password)
        {
            using (var db = new TelstarLogisticsContext())
            {
                db.Persons.Add(new Employee
                {
                    Name= name,
                    Password = password
                });

                db.SaveChanges();
            }
        }
    }
}