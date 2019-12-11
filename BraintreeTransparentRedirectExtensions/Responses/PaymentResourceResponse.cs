using BraintreeRedirectExtensions.Models;
using Newtonsoft.Json;

namespace BraintreeRedirectExtensions.Responses
{
    internal class PaymentResourceResponse
    {
        [JsonProperty("paymentResource")]
        public PaymentResource PaymentResource { get; set; }
    }
}
