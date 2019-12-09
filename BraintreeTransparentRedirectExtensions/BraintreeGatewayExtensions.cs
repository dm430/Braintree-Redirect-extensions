﻿using System.Net.Http;
using System.Threading.Tasks;
using Braintree;
using BraintreeTransparentRedirectExtensions.Http;
using BraintreeTransparentRedirectExtensions.Models;
using BraintreeTransparentRedirectExtensions.Services;

namespace BraintreeTransparentRedirectExtensions
{
    public static class BraintreeGatewayExtensions
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly IWebClient webClient = new WebClientWrapper();

        public static async Task<PaymentResource> CreateLocalPaymentAsync(this IClientTokenGateway clientTokenGateway, string merchantAccountId, LocalPayment localPayment)
        {
            var service = new BraintreeLocalPaymentService(clientTokenGateway, httpClient, webClient);

            return await service.CreateLocalPaymentAsync(merchantAccountId, localPayment);
        }

        public static PaymentResource CreateLocalPayment(this IClientTokenGateway clientTokenGateway, string merchantAccountId, LocalPayment localPayment)
        {
            var service = new BraintreeLocalPaymentService(clientTokenGateway, httpClient, webClient);

            return service.CreateLocalPayment(merchantAccountId, localPayment);
        }
    }
}