using BraintreeTransparentRedirectExtensions.Models;
using Newtonsoft.Json;

namespace BraintreeTransparentRedirectExtensions.Responses
{
    internal class PaymentResourceResponse
    {
        [JsonProperty("paymentResource")]
        public PaymentResource PaymentResource { get; set; }
    }
}
