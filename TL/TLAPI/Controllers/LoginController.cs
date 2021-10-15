using System.Net;
using System.Web.Http;
using TelstarLogistics.DataAccess;
using TelstarLogistics.DataAccess.Entities;
using TLAPI.Models;
using TLAPI.Services;

namespace TLAPI.Controllers
{
    /// <summary>
    /// This controller exposes the endpoint for retrieving employee
    /// and customer information <see cref="LoginService"/>.
    /// </summary>
     [RoutePrefix("login")]
    public class LoginController : ApiController
    {
        private readonly ILogin _iLogin;

        public LoginController()
        {
            TelstarLogisticsContext dbContext = new TelstarLogisticsContext();
            _iLogin = new LoginService(dbContext);
        }

        //[HttpPost]
        //public void GetEmployeeLogin(GetEmployeeLoginRequest request)
        //{
        //    if (_iLogin.GetEmployeeLogin(request))
        //    {
        //        return;
        //    }
        //    throw new HttpResponseException(HttpStatusCode.Unauthorized);
        //}

        [Route("GetCustomer")]
        [HttpGet]
        public Customer GetCustomerInformation(int request)
        {
            return _iLogin.GetCustomerId(request);
        }

        [Route("CreateCustomer")]
        [HttpPost]
        public Customer CreateCustomerId(CreateCustomerRequest request)
        {
            return _iLogin.CreateCustomerId(request);
        }

    }
}