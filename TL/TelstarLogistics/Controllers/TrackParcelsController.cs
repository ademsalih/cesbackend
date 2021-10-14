using System;
using System.Collections.Generic;
using System.Web.Http;
using TelstarLogistics.DataAccess.Classes;
using TelstarLogistics.Requests;
using TelstarLogistics.Services;

namespace TelstarLogistics.Controllers
{
    /// <summary>
    /// This controller exposes the endpoint for retrieving the list of parcels and their
    /// updated statuses from <see cref="TrackParcelsController"/>.
    /// </summary>
    public class TrackParcelsController : ApiController
    {
        private readonly ITrackParcelService _trackParcelService;
        //TODO: change to request?
        private Order order;

        public TrackParcelsController(ITrackParcelService trackParcelService)
        {
            _trackParcelService = trackParcelService;
        }

        //Get order list
        [HttpGet]
        public List<Order> GetOrderList()
        {
            if (ModelState.IsValid)
            {
                return _trackParcelService.GetOrderList();
            }

            throw new ArgumentException("The input request is not valid");
        }

        [HttpPatch]
        public Order UpdateOrder(StatusRequest request)
        {

            if (!ModelState.IsValid)
            {
                throw new ArgumentException("The input request is not valid.");
            }

            return _trackParcelService.UpdateStatus(request);
        }

    }
}