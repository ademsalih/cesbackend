using TelstarLogistics.DataAccess.Classes;

namespace TLAPI.Models
{
    public class MakeAnOrderResponse
    {
        public Customer Customer { get; set; }
        public Parcel Parcel { get; set; }
        public Route Route { get; set; }
    }
}