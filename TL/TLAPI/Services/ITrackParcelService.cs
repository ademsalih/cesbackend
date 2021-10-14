using System.Collections.Generic;
using TelstarLogistics.DataAccess.Classes;
using TLAPI.Models;

namespace TLAPI.Services
{
    public interface ITrackParcelService
    {
        List<Order> GetOrderList();

        Order UpdateStatus(StatusRequest request);
    }
}