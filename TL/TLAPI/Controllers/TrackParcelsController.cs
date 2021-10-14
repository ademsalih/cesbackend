using System.Collections.Generic;
using System.Web.Http;
using TelstarLogistics.DataAccess.Classes;
using TelstarLogistics.Services;
using TLAPI.Models;
using TLAPI.Services;

namespace TLAPI.Controllers
{
    /// <summary>
    /// This controller exposes the endpoint for retrieving the list of parcels and their
    /// updated statuses from <see cref="TrackParcelsController"/>.
    /// </summary>
    public class TrackParcelsController : ApiController
    {
        private readonly ITrackParcelService _trackParcelService;

        public TrackParcelsController(ITrackParcelService trackParcelService)
        {
            _trackParcelService = trackParcelService;
        }

        [HttpGet]
        public List<Order> GetOrderList()
        {
            return _trackParcelService.GetOrderList();
        }

        [HttpPatch]
        public Order UpdateOrder(StatusRequest request)
        {
            return _trackParcelService.UpdateStatus(request);
        }

    }
}