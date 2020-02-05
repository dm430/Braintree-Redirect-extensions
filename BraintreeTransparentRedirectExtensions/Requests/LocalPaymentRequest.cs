using BraintreeRedirectExtensions.Utilities;
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

        [JsonProperty("experienceProfile")]
        public ExperienceProfileRequest ExperienceProfile { get; internal set; }

        [JsonProperty("line1", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressLine1 { get; internal set; }

        [JsonProperty("line2", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressLine2 { get; internal set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string Locality { get; internal set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get; internal set; }

        [JsonProperty("postalCode", NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; internal set; }

        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; internal set; }

        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; internal set; }

        [JsonProperty("payerEmail", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; internal set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; internal set; }
    }
}
