namespace BraintreeRedirectExtensions.Models.Configuration
{
    internal class PaypalConfiguration
    {
        public string DisplayName { get; internal set; }
        public string ClientId { get; internal set; }
        public string PrivacyUrl { get; internal set; }
        public string UserAgreementUrl { get; internal set; }
        public string BaseUrl { get; internal set; }
        public string AssetsUrl { get; internal set; }
        public object DirectBaseUrl { get; internal set; }
        public bool AllowHttp { get; internal set; }
        public bool EnvironmentNoNetwork { get; internal set; }
        public string Environment { get; internal set; }
        public bool UnvettedMerchant { get; internal set; }
        public string BraintreeClientId { get; internal set; }
        public bool BillingAgreementsEnabled { get; internal set; }
        public string MerchantAccountId { get; internal set; }
        public string CurrencyIsoCode { get; internal set; }
    }
}