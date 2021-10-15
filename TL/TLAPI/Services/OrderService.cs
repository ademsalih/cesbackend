using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelstarLogistics.DataAccess;

namespace TLAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly TelstarLogisticsContext _dbContext;

        public OrderService(TelstarLogisticsContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void SaveOrder()
        {

        }
    }
}