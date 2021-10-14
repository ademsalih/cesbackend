using System.Linq;
using TelstarLogistics.DataAccess;
using TelstarLogistics.DataAccess.Entities;
using TLAPI.Models;

namespace TLAPI.Services
{
    /// <summary>
    /// Purpose: retrieve or create log in information for a customer or employee.
    /// </summary>

    public class LoginService : ILogin
    {
        private readonly TelstarLogisticsContext _dbContext;

        public LoginService(TelstarLogisticsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool GetEmployeeLogin(GetEmployeeLoginRequest request)
        {
            var loginList = _dbContext.Persons.ToList();

            var check = loginList
                            .Select(list => list.MailAddress)
                            .Contains(request.Mail) 
                        || 
                        loginList
                            .Where(list => list.MailAddress == request.Mail)
                            .Select(list => list.Password)
                            .Contains(request.Password);

            return check;
        }

        public Customer GetCustomerId(int request)
        {
            var customerList = _dbContext.Customers.ToList();

            return customerList.First(list => list.PersonId == request);
        }

        public Customer CreateCustomerId(CreateLoginRequest request)
        {
            var newCustomer = new Customer()
            {
                PersonId = new int(),
                Name = request.Name,
                Address = new Address()
                {
                    AddressId = new int(),
                    AddressLine = request.AddressLine,
                    City = request.City,
                    Country = request.Country,
                    PostCode = request.PostCode
                },
                Mail = request.Mail,
                CardHolder = request.CardHolder,
                CreditCard = request.CreditCard,
                Cvv = request.Cvv,
                DateTime = request.DateTime
            };

            return newCustomer;
        }
    }
}