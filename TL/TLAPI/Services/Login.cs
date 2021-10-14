using System.Linq;
using TelstarLogistics.DataAccess;
using TLAPI.Models;

namespace TLAPI.Services
{
    /// <summary>
    /// Purpose: retrieve or create log in information for a customer or employee.
    /// </summary>

    public class Login : ILogin
    {
        private readonly TelstarLogisticsContext _dbContext;

        public Login(TelstarLogisticsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool GetEmployeeLogin(GetEmployeeLoginRequest request)
        {
            var loginList = _dbContext.Persons.ToList();

            if (loginList
                    .Select(list => list.MailAddress)
                    .Contains(request.Mail)
                || 
                loginList
                    .Where(list => list.MailAddress == request.Mail)
                    .Select(list => list.Password)
                    .Contains(request.Password))
            {
                return true;
            }

            return false;
        }

        public bool GetCustomerId(int request)
        {
            var customerList = _dbContext.Customers.ToList();

            if (customerList
                .Select(list => list.PersonId)
                .Contains(request))
            {
                return true;

                //TODO: return all customer id?
            }

            return false;
        }

    }
}