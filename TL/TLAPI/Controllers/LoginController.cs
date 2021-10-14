using System.Web.Http;
using TLAPI.Models;
using TLAPI.Services;

namespace TLAPI.Controllers
{
    /// <summary>
    /// This controller exposes the endpoint for retrieving log in data <see cref="Login"/>.
    /// </summary>
    public class LoginController : ApiController
    {
        private readonly ILogin _iLogin;
        
        public LoginController(ILogin iLogin)
        {
            _iLogin = iLogin;
        }

        [HttpGet]
        public bool GetEmployeeLogin(GetEmployeeLoginRequest request)
        {
            return _iLogin.GetEmployeeLogin(request);
        }

        [HttpGet]
        public bool GetCustomerInformation(int request)
        {
            return _iLogin.GetCustomerId(request);
        }

    }
}