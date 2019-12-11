using System.Collections.Generic;
using Newtonsoft.Json;

namespace BraintreetRedirectExtensions.Models.Configuration
{
    internal class BraintreeClientConfiguration
    {
        [JsonProperty("version")]
        public int Version { get;  set; }

        [JsonProperty("authorizationFingerprint")]
        public string AuthorizationFingerprint { get;  set; }

        [JsonProperty("configUrl")]
        public string ConfigUrl { get; set; }

        [JsonProperty("graphQL")]
        public GraphQLConfiguration GraphQl { get; internal set; }

        [JsonProperty("challenges")]
        public List<object> Challenges { get; internal set; }

        [JsonProperty("environment")]
        public string Environment { get; internal set; }

        [JsonProperty("clientApiUrl")]
        public string ClientApiUrl { get; internal set; }

        [JsonProperty("assetsUrl")]
        public string AssetsUrl { get; internal set; }

        [JsonProperty("authUrl")]
        public string AuthUrl { get; internal set; }

        [JsonProperty("analytics")]
        public AnalyticsConfiguration Analytics { get; internal set; }

        [JsonProperty("threeDSecureEnabled")]
        public bool ThreeDSecureEnabled { get; internal set; }

        [JsonProperty("paypalEnabled")]
        public bool PaypalEnabled { get; internal set; }

        [JsonProperty("paypal")]
        public PaypalConfiguration Paypal { get; internal set; }

        [JsonProperty("merchantId")]
        public string MerchantId { get; internal set; }

        [JsonProperty("venmo")]
        public string Venmo { get; internal set; }

        [JsonProperty("merchantAccountId")]
        public string MerchantAccountId { get; internal set; }
    }
}
