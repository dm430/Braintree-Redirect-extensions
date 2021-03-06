﻿using Newtonsoft.Json;

namespace BraintreeRedirectExtensions.Models
{
    public class PaymentResource
    {
        [JsonProperty("paymentToken")]
        public string PaymentId { get; internal set; }

        [JsonProperty("intent")]
        public string Intent { get; internal set; }

        [JsonProperty("redirectUrl")]
        public string RedirectUrl { get; internal set; }
    }
}
