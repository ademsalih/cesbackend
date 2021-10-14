using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelstarLogistics.DataAccess.Classes
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public Address Address { get;set}
        public int PostCode { get; set;}
        public string CardHolder { get; set; }
        public int CreditCard { get; set; }
        public int Cvv { get; set; }
        public DateTime DateTime { get; set; }
    }
}
