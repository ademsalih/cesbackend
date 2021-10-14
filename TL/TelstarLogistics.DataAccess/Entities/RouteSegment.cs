using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelstarLogistics.DataAccess.Classes
{
    public class RouteSegment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RouteSegmentId { get; set; }
        public string CityTo { get; set; }
        public string CityFrom { get; set; }
        public double Price { get; set; }
        public double Duration { get; set; }
    }
}