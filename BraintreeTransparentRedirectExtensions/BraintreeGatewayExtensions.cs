using System.Net.Http;
using System.Threading.Tasks;
using Braintree;
using BraintreeRedirectExtensions.Http;
using BraintreeRedirectExtensions.Models;
using BraintreeRedirectExtensions.Services;

namespace BraintreeRedirectExtensions
{
    /// <summary>
    /// A static extension that provides additional payment related functionality to the Braintree gateway.
    /// </summary>
    public static class BraintreeGatewayExtensions
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly IWebClient webClient = new WebClientWrapper();

        /// <summary>
        /// Creates a local payment transaction using the Braintree payment gateway.
        /// </summary>
        /// <param name="clientTokenGateway">The Braintree clinet token gateway.</param>
        /// <param name="merchantAccountId">The merchant account to use for the paymnt.</param>
        /// <param name="localPayment">Descriptor of the payment to be created on the brain tree server.</param>
        /// <returns>A payment resource that describes the newly created payment.</returns>
        public static Task<PaymentResource> CreateLocalPaymentAsync(this IClientTokenGateway clientTokenGateway, string merchantAccountId, LocalPayment localPayment)
        {
            var service = new BraintreeLocalPaymentService(clientTokenGateway, httpClient, webClient);

            return service.CreateLocalPaymentAsync(merchantAccountId, localPayment);
        }

        /// <summary>
        /// Creates a local payment transaction using the Braintree payment gateway.
        /// </summary>
        /// <param name="clientTokenGateway">The Braintree clinet token gateway.</param>
        /// <param name="merchantAccountId">The merchant account to use for the paymnt.</param>
        /// <param name="localPayment">Descriptor of the payment to be created on the brain tree server.</param>
        /// <returns>A payment resource that describes the newly created payment</returns>
        public static PaymentResource CreateLocalPayment(this IClientTokenGateway clientTokenGateway, string merchantAccountId, LocalPayment localPayment)
        {
            var service = new BraintreeLocalPaymentService(clientTokenGateway, httpClient, webClient);

            return service.CreateLocalPayment(merchantAccountId, localPayment);
        }
    }
}