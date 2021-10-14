using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelstarLogistics.Models
{
    public class FindRouteResponse
    {
        public double Cost { get; set; }
        public double Time { get; set; }
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
    }
}