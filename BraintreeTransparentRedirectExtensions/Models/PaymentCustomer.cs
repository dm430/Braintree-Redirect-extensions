using System;
using System.Collections.Generic;
using System.Text;

namespace BraintreeRedirectExtensions.Models
{
    public class PaymentCustomer
    {
        public PaymentCustomer(string firstName = null, string lastName = null, string email = null, string phone = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}