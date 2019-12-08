using Braintree;
using BraintreeTransparentRedirectExtensions.Models;
using BraintreeTransparentRedirectExtensions.Requests;
using BraintreeTransparentRedirectExtensions.Responses;
using BraintreeTransparentRedirectExtensions.Utilities;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BraintreeTransparentRedirectExtensions.Services
{
    public class BraintreeLocalPaymentService : IBraintreeLocalPaymentService {
        private const string paymentCreateEnpoint = "/v1/local_payments/create";

        private readonly IClientTokenGateway clientTokenGateway;
        private readonly HttpClient httpClient;

        public BraintreeLocalPaymentService(IClientTokenGateway clientTokenGateway, HttpClient httpClient)
        {
            this.clientTokenGateway = clientTokenGateway;
            this.httpClient = httpClient;
        }

        public async Task<PaymentResource> CreateLocalPaymentAsync(string merchantAccountId, LocalPayment localPayment)
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
            var response = await httpClient.PostAsync<PaymentResourceResponse, LocalPaymentRequest>($"{clientConfiguration.ClientApiUrl}{paymentCreateEnpoint}", localPaymentRequest);

            return response.PaymentResource;
        }
    }
}
