using System;

namespace BraintreeRedirectExtensions.Models
{
    public class LocalPayment
    {
        public LocalPayment(string paymentType, decimal amount, string currencyCode, PaymentAddress address, PaymentFallback fallback, string cancelUrl, PaymentCustomer customer = null, bool addressEntryRequired = false) 
            : this(paymentType, amount, currencyCode, address, fallback, new Uri(cancelUrl), customer, addressEntryRequired) { }

        public LocalPayment(string paymentType, decimal amount, string currencyCode, PaymentAddress address, PaymentFallback fallback, Uri cancelUrl, PaymentCustomer customer = null, bool addressEntryRequired = false)
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

            PaymentType = paymentType;
            Amount = amount;
            CurrencyCode = currencyCode;
            Address = address ?? throw new ArgumentNullException(nameof(address), "The address cannot be null.");
            Fallback = fallback ?? throw new ArgumentNullException(nameof(fallback), "The fallback cannot be null.");
            CancelUrl = cancelUrl ?? throw new ArgumentNullException(nameof(CancelUrl), "The cancel url cannot be null.");
            Customer = customer;
            AddressEntryRequired = addressEntryRequired;
        }

        public string PaymentType { get; protected set; }
        public decimal Amount { get; protected set; }
        public PaymentFallback Fallback { get; protected set; }
        public Uri CancelUrl { get; protected set; }
        public string CurrencyCode { get; protected set; }
        public PaymentAddress Address { get; protected set; }
        public PaymentCustomer Customer { get; set; }
        public bool AddressEntryRequired { get; set; }
    }
}