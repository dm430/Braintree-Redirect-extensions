using System;
using System.Net.Http;
using System.Threading.Tasks;
using Braintree;
using BraintreeTransparentRedirectExtensions.Models;
using BraintreeTransparentRedirectExtensions.Requests;
using BraintreeTransparentRedirectExtensions.Responses;
using BraintreeTransparentRedirectExtensions.Utilities;

namespace BraintreeTransparentRedirectExtensions
{
    public static class BraintreeGatewayExtensions
    {
        private static readonly HttpClient Client = new HttpClient();

        public static async Task<PaymentResource> CreateLocalPaymentAsync(this IClientTokenGateway clientTokenGateway, string merchantAccountId, LocalPayment localPayment)
        {
            if (string.IsNullOrWhiteSpace(merchantAccountId))
            {
                throw new ArgumentException("The merchant account id cannot be null or whitespace.", nameof(merchantAccountId));
            }

            if (localPayment == null)
            {
                throw new ArgumentNullException(nameof(localPayment), "The local payment cannot be null.");
            }

            var clientConfiguration = await clientTokenGateway.GetClientConfigurationAsync(merchantAccountId);
            var localPaymentRequest = RequestFactory.CreateLocalPaymentRequest(localPayment, clientConfiguration);
            var response = await Client.PostAsync<PaymentResourceResponse, LocalPaymentRequest>($"{clientConfiguration.ClientApiUrl}/v1/local_payments/create", localPaymentRequest);

            return response.PaymentResource;
        }

        public static PaymentResource CreateLocalPayment(this IClientTokenGateway clientTokenGateway, string merchantAccountId, LocalPayment localPayment)
        {
            // TODO: This can lock use all sync calls.  
            return clientTokenGateway.CreateLocalPaymentAsync(merchantAccountId, localPayment).GetAwaiter().GetResult();
        }
    }
}