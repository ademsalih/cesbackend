using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelstarLogistics.DataAccess.Classes
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
