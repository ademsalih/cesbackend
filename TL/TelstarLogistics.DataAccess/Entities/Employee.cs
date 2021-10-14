using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelstarLogistics.DataAccess.Classes
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        public string MailAddress { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}