using System.Collections.Generic;
using System.Linq;
using TelstarLogistics.DataAccess;
using TelstarLogistics.DataAccess.Classes;
using TelstarLogistics.Services;
using TLAPI.Models;
using TLAPI.Services;

namespace TLAPI.Services{
    /// <summary>
    /// Purpose: generate list of orders made with current delivery status and
    /// update delivery status.
    /// </summary>

    public class TrackParcelService : ITrackParcelService
    {
        private readonly TelstarLogisticsContext _dbContext;

        public TrackParcelService(TelstarLogisticsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Order> GetOrderList()
        {
            //Get updated order list
            var orderList = _dbContext.Orders.ToList();
          
            return orderList;
        }

        public Order UpdateStatus(StatusRequest request)
        {
            //Retrieve orders from database
            var orderDatabase = _dbContext.Orders.ToList();

            //Retrieve order with same order id as the order id from request
            var order = orderDatabase
                .First(o => o.OrderId == request.OrderId);

            //Update status
            if (request.Delivered)
            {
                request.ShippingStatus = true;
                order.Delivered = true;
                order.ShippingStatus = true;

                _dbContext.SaveChanges();
            }

            return order;
        }
    }
}