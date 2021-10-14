using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelstarLogistics.DAL.Classes;

namespace TelstarLogistics.DataAccess.Classes
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Employee CreatedBy { get; set; }
        public Customer Customer { get; set; }
        public Parcel Parcel { get; set; }
        public Route Route { get; set; }
    }
}
