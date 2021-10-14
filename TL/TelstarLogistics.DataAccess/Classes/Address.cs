using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelstarLogistics.DataAccess.Enum;

namespace TelstarLogistics.DataAccess.Classes
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        public string AddressLine { get; set; }
        public int PostCode { get; set; }
        public City City { get; set; }
        public string Country { get; set; }
    }
}
