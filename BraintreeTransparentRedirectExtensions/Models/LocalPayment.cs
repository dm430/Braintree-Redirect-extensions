namespace BraintreeTransparentRedirectExtensions.Models
{
    public class LocalPayment
    {
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public PaymentFallback Fallback { get; set; }
        public string CancelUrl { get; set; }
        public string CurrencyCode { get; set; }
        public string CountryCode { get; set; }
    }
}