using System;
using TelstarLogistics.DataAccess.Classes;
using TelstarLogistics.DataAccess.Entities;

namespace TLAPI.Models
{
    public class MakeAnOrderRequest
    {
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public double Price { get; set; }
        public double Duration { get; set; }
        
    }
}