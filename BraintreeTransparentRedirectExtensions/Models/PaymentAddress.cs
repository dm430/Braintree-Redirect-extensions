using System;

namespace BraintreeRedirectExtensions.Models
{
    public class PaymentAddress
    {
        public PaymentAddress(string countryCode, string addressLine1 = null, string addressLine2 = null, string locality = null, string region = null, string postalCode = null)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
            {
                throw new ArgumentException("The payment country code be null or whitespace.", nameof(countryCode));
            }

            CountryCode = countryCode;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Locality = locality;
            Region = region;
            PostalCode = postalCode;
        }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; internal set; }
    }
}
