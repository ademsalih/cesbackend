using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelstarLogistics.DataAccess.Enum;

namespace TelstarLogistics.DataAccess.Classes
{
    public class Parcel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParcelId { get; set; }
        public Type Type { get; set; }
        public double Weight { get; set; }
        public double SizeLength { get; set; }
        public double SizeWidth { get; set; }
        public double SizeHeight { get; set; }
    }
}