using System.Collections.Generic;
using TelstarLogistics.DataAccess.Classes;
using TelstarLogistics.Requests;

namespace TelstarLogistics.Services
{
    public interface ITrackParcelService
    {
        List<Order> GetOrderList();

        Order UpdateStatus(StatusRequest request);
    }
}