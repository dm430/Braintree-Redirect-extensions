using Newtonsoft.Json;

namespace BraintreeRedirectExtensions.Requests
{
    internal class LocalPaymentRequest
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("intent")]
        public string Intent { get; set; }

        [JsonProperty("returnUrl")]
        public string ReturnUrl { get; set; }

        [JsonProperty("cancelUrl")]
        public string CancelUrl { get; set; }

        [JsonProperty("currencyIsoCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("fundingSource")]
        public string FundingSource { get; set; }

        [JsonProperty("braintreeLibraryVersion")]
        public string BraintreeLibraryVersion { get; set; }

        [JsonProperty("_meta")]
        public MetaData MetaData { get; set; }

        [JsonProperty("authorizationFingerprint")]
        public string AuthorizationFingerprint { get; set; }
    }
}
