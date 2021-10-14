using System.Collections.Generic;
using System.Linq;
using TelstarLogistics.DataAccess.Classes;
using TelstarLogistics.Requests;

namespace TelstarLogistics.Services{
    /// <summary>
    /// Purpose: generate list of orders made with current delivery status and
    /// update delivery status.
    /// </summary>

    public class TrackParcelService : ITrackParcelService
    {
        public List<Order> GetOrderList()
        {
            //Get updated order list
            //TODO: retrieve list from database
            var updatedList = new List<Order>();
          
            return updatedList;
        }

        public Order UpdateStatus(StatusRequest request)
        {
            //TODO: Fetch order from database from request Id
            var orderDatabase = new List<Order>();

            var order = orderDatabase
                .First(o => o.OrderId == request.OrderId);

            //Update status
            if (request.DeliveryStatus)
            {
                request.ShippingStatus = true;
                order.Delivered = true;
                order.ShippingStatus = true;
            }

            return order;
        }
    }
}