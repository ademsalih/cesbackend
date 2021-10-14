﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelstarLogistics.DataAccess.Enum;

namespace TelstarLogistics.DataAccess.Classes
{
    public class RouteSegment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RouteSegmentId { get; set; }
        public City CityTo { get; set; }
        public City CityFrom { get; set; }
        public double Price { get; set; }
        public double Duration { get; set; }
    }
}