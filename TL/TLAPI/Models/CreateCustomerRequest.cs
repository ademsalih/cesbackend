using System;

namespace TLAPI.Models
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string AddressLine { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CardHolder { get; set; }
        public int CreditCard { get; set; }
        public int Cvv { get; set; }
        public DateTime DateTime { get; set; }
    }
}