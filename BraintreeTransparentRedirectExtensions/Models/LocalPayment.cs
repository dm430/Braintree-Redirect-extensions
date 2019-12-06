using System;

namespace BraintreeTransparentRedirectExtensions.Models
{
    public class LocalPayment
    {
        public LocalPayment(string paymentType, decimal amount, string currencyCode, string countryCode, PaymentFallback fallback, string cancelUrl) 
            : this(paymentType, amount, currencyCode, countryCode, fallback, new Uri(cancelUrl)) { }

        public LocalPayment(string paymentType, decimal amount, string currencyCode, string countryCode, PaymentFallback fallback, Uri cancelUrl)
        {
            if (string.IsNullOrWhiteSpace(paymentType))
            {
                throw new ArgumentException("The payment type cannot be null or whitespace.", nameof(paymentType));
            }

            if (amount <= 0)
            {
                throw new ArgumentException("The payment ammount must be greater than 0.", nameof(amount));
            }

            if (string.IsNullOrWhiteSpace(currencyCode))
            {
                throw new ArgumentException("The payment currency code be null or whitespace.", nameof(currencyCode));
            }
            
            if (string.IsNullOrWhiteSpace(countryCode))
            {
                throw new ArgumentException("The payment country code be null or whitespace.", nameof(countryCode));
            }

            PaymentType = paymentType;
            Amount = amount;
            CurrencyCode = currencyCode;
            CountryCode = countryCode;
            Fallback = fallback ?? throw new ArgumentNullException(nameof(fallback), "The fallback cannot be null.");
            CancelUrl = cancelUrl ?? throw new ArgumentNullException(nameof(CancelUrl), "The cancel url cannot be null.");
        }

        public string PaymentType { get; protected set; }
        public decimal Amount { get; protected set; }
        public PaymentFallback Fallback { get; protected set; }
        public Uri CancelUrl { get; protected set; }
        public string CurrencyCode { get; protected set; }
        public string CountryCode { get; protected set; }
    }
}