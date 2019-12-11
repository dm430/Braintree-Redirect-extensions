using System;

namespace BraintreeRedirectExtensions.Requests
{
    internal class MetaData
    {
        public string MerchantAppId { get; set; }
        public string Platform { get; set; }
        public string SdkVersion { get; set; }
        public string Source { get; set; }
        public string Integration { get; set; }
        public string IntegrationType { get; set; }
        public Guid SessionId { get; set; }
    }
}