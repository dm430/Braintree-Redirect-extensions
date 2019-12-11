using BraintreetRedirectExtensions.Models;
using Newtonsoft.Json;

namespace BraintreetRedirectExtensions.Responses
{
    internal class PaymentResourceResponse
    {
        [JsonProperty("paymentResource")]
        public PaymentResource PaymentResource { get; set; }
    }
}
