using System;
using TelstarLogistics.DataAccess.Classes;
using TelstarLogistics.DataAccess.Entities;

namespace TLAPI.Models
{
    public class MakeAnOrderRequest
    {
        public Customer Customer { get; set; }
        public Parcel Parcel { get; set; }
        public RouteSegment Route { get; set; }
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public double Price { get; set; }
        public double Duration { get; set; }
        
    }
}