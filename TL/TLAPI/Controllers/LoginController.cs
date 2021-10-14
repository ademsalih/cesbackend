using System;
using System.Net;
using System.Web.Http;
using TelstarLogistics.DataAccess.Classes;
using TelstarLogistics.DataAccess.Entities;
using TLAPI.Models;
using TLAPI.Services;

namespace TLAPI.Controllers
{
    /// <summary>
    /// This controller exposes the endpoint for retrieving log in data <see cref="LoginService"/>.
    /// </summary>
    public class LoginController : ApiController
    {
        private readonly ILogin _iLogin;
        
        public LoginController(ILogin iLogin)
        {
            _iLogin = iLogin;
        }

        [HttpPost]
        public void GetEmployeeLogin(GetEmployeeLoginRequest request)
        {
            if(_iLogin.GetEmployeeLogin(request))
            {
                return;
            }
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        [HttpGet]
        public Customer GetCustomerInformation(int request)
        {
            return _iLogin.GetCustomerId(request);
        }

    }
}