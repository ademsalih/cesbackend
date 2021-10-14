
using TLAPI.Models;

namespace TLAPI.Services
{
    public interface ILogin
    {
        bool GetEmployeeLogin(GetEmployeeLoginRequest request);

        bool GetCustomerId(int request);
    }
}