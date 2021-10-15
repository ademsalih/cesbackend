using TelstarLogistics.DataAccess.Classes;
using TelstarLogistics.DataAccess.Entities;

namespace TLAPI.Models
{
    public class MakeAnOrderRequest
    {
        public Customer Customer { get; set; }
        public Parcel Parcel { get; set; }
        public Route Route { get; set; }

    }
}