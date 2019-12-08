using System.Net.Http;
using System.Threading.Tasks;
using Braintree;
using BraintreeTransparentRedirectExtensions.Models;
using BraintreeTransparentRedirectExtensions.Services;

namespace BraintreeTransparentRedirectExtensions
{
    public static class BraintreeGatewayExtensions
    {
        private static readonly HttpClient Client = new HttpClient();

        public static async Task<PaymentResource> CreateLocalPaymentAsync(this IClientTokenGateway clientTokenGateway, string merchantAccountId, LocalPayment localPayment)
        {
            var service = new BraintreeLocalPaymentService(clientTokenGateway, Client);

            return await service.CreateLocalPaymentAsync(merchantAccountId, localPayment);
        }

        public static PaymentResource CreateLocalPayment(this IClientTokenGateway clientTokenGateway, string merchantAccountId, LocalPayment localPayment)
        {
            // TODO: This can lock use all sync calls.  
            return clientTokenGateway.CreateLocalPaymentAsync(merchantAccountId, localPayment).GetAwaiter().GetResult();
        }
    }
}