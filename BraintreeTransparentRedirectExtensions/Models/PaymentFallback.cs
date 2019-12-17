using System;

namespace BraintreeRedirectExtensions.Models
{
    public class PaymentFallback
    {
        public PaymentFallback(string url, string buttonText = null) : this (new Uri(url), buttonText) { }

        public PaymentFallback(Uri url, string buttonText = null)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url), "The fallback url cannot be null.");
            ButtonText = buttonText;
        }

        public Uri Url { get; protected set; }
        public string ButtonText { get; protected set; }
        public bool HasRedirectButton => !string.IsNullOrWhiteSpace(ButtonText);
    }
}