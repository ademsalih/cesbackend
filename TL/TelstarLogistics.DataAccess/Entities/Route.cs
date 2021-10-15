using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelstarLogistics.DataAccess.Entities;

namespace TelstarLogistics.DataAccess.Classes
{
    public class Route
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RouteId { get; set; }
        public RouteSegment RouteSegment { get; set; }
        public double Price { get; set; }
        public double AdjustedPrice { get; set; }
        public double Duration { get; set; }
    }
}