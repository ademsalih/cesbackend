using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelstarLogistics.Models
{
    public class FindRouteRequest
    {
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }
    }
}