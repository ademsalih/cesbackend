using TelstarLogistics.DataAccess.Entities;
using TLAPI.Models;

namespace TLAPI.Services
{
    public interface ILogin
    {
        bool GetEmployeeLogin(GetEmployeeLoginRequest request);

        Customer GetCustomerId(int request);

        Customer CreateCustomerId(CreateCustomerRequest request);
    }
}