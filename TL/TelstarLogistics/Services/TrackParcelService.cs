using System.Collections.Generic;
using System.Linq;
using TelstarLogistics.DataAccess.Classes;

namespace TelstarLogistics.Services{
    /// <summary>
    /// Purpose: generate list of orders made with current delivery status.
    /// </summary>

    public class TrackParcelService
    {
        public List<Order> GetOrderList()
        {
            //Get order list from database
            //TODO: retrieve from database
            var updatedList = new List<Order>();

            return updatedList;
        }

        public List<Order> UpdateOrderList (Order order)
        {
            //TODO: retrieve from database
            var orderList = new List<Order>();

            var idList = orderList.Select(list => list.OrderId).ToList();

            //Should add order to list every time a new order is made
            if(!idList.Contains(order.OrderId))
            {
                orderList.Add(order);

                //Add tracking number to an order
                CreateTrackingNumber(order);

                //Add status to an order
                UpdateStatus(order);
            }

            return orderList;
        }

        private void CreateTrackingNumber(Order order)
        {
            order.TrackingNumber = new int();
        }

        private void UpdateStatus(Order order)
        {
            //Default status
            order.ShippingStatus = false;

            //Update status
            //TODO: how is message received from front end?
            if (order.Delivered == true)
            {
                order.ShippingStatus = true;
            }
        }
    }
}