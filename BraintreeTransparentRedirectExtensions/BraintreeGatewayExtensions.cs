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
            var clientConfiguration = await clientTokenGateway.GetClientConfigurationAsync(merchantAccountId);
            var localPaymentRequest = RequestFactory.CreateLocalPaymentRequest(localPayment, clientConfiguration);
            var response = await Client.PostAsync<PaymentResourceResponse, LocalPaymentRequest>($"{clientConfiguration.ClientApiUrl}/v1/local_payments/create", localPaymentRequest);

            return response.PaymentResource;
        }

        public static PaymentResource CreateLocalPayment(this IClientTokenGateway clientTokenGateway, string merchantAccountId, LocalPayment localPayment)
        {
            // TODO: Use all sync calls.
            return clientTokenGateway.CreateLocalPaymentAsync(merchantAccountId, localPayment).GetAwaiter().GetResult();
        }
    }
}