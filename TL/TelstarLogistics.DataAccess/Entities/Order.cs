using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelstarLogistics.DataAccess.Entities;

namespace TelstarLogistics.DataAccess.Classes
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public Employee CreatedBy { get; set; }
        public Customer Customer { get; set; }
        public Parcel Parcel { get; set; }
        public Route Route { get; set; }

        public int TrackingNumber { get; set; }

        //false = in shipment, true = delivered
        public bool ShippingStatus { get; set; }
        public bool Delivered { get; set; }
    }
}
