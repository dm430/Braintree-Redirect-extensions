using Braintree;
using BraintreeRedirectExtensions.Models;
using BraintreeRedirectExtensions.Requests;
using BraintreeRedirectExtensions.Responses;
using BraintreeRedirectExtensions.Utilities;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BraintreeRedirectExtensions.Services
{
    public class BraintreeLocalPaymentService : IBraintreeLocalPaymentService {
        private const string paymentCreateEnpoint = "/v1/local_payments/create";

        private readonly IClientTokenGateway clientTokenGateway;
        private readonly HttpClient httpClient;

        public BraintreeLocalPaymentService(IClientTokenGateway clientTokenGateway, HttpClient httpClient, IWebClient webClient)
        {
            this.clientTokenGateway = clientTokenGateway;
            this.httpClient = httpClient;
        }

        public async Task<PaymentResource> CreateLocalPaymentAsync(string merchantAccountId, LocalPayment localPayment)
        {
            ValidateParameters(merchantAccountId, localPayment);

            var clientConfiguration = await clientTokenGateway.GetClientConfigurationAsync(merchantAccountId)
                .ConfigureAwait(false);
            var localPaymentRequest = RequestFactory.CreateLocalPaymentRequest(localPayment, clientConfiguration);
            var response = await httpClient.PostAsync<PaymentResourceResponse, LocalPaymentRequest>($"{clientConfiguration.ClientApiUrl}{paymentCreateEnpoint}", localPaymentRequest)
                .ConfigureAwait(false);

            return response.PaymentResource;
        }

        public PaymentResource CreateLocalPayment(string merchantAccountId, LocalPayment localPayment)
        {
            ValidateParameters(merchantAccountId, localPayment);

            var clientConfiguration = clientTokenGateway.GetClientConfiguration(merchantAccountId);
            var localPaymentRequest = RequestFactory.CreateLocalPaymentRequest(localPayment, clientConfiguration);

            var webClient = new WebClient();
            var response = webClient.Post<PaymentResourceResponse, LocalPaymentRequest>($"{clientConfiguration.ClientApiUrl}{paymentCreateEnpoint}", localPaymentRequest);

            return response.PaymentResource;
        }

        private static void ValidateParameters(string merchantAccountId, LocalPayment localPayment)
        {
            if (string.IsNullOrWhiteSpace(merchantAccountId))
            {
                throw new ArgumentException("The merchant account id cannot be null or whitespace.", nameof(merchantAccountId));
            }

            if (localPayment == null)
            {
                throw new ArgumentNullException(nameof(localPayment), "The local payment cannot be null.");
            }
        }
    }
}
