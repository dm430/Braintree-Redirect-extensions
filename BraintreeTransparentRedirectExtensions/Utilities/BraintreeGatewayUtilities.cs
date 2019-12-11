using System.Threading.Tasks;
using Braintree;
using BraintreetRedirectExtensions.Models.Configuration;
using Newtonsoft.Json;

namespace BraintreetRedirectExtensions.Utilities
{
    public static class BraintreeGatewayUtilities
    {
        internal static BraintreeClientConfiguration GetClientConfiguration(this IClientTokenGateway clientTokenGateway, string merchantAccountId)
        {
            var clientToken = clientTokenGateway.Generate(new ClientTokenRequest()
            {
                MerchantAccountId = merchantAccountId
            });

            return DecodeClientToken(clientToken);
        }

        internal static async Task<BraintreeClientConfiguration> GetClientConfigurationAsync(this IClientTokenGateway clientTokenGateway, string merchantAccountId)
        {
            var clientToken = await clientTokenGateway.GenerateAsync(new ClientTokenRequest()
            {
                MerchantAccountId = merchantAccountId
            });

            return DecodeClientToken(clientToken);
        }

        private static BraintreeClientConfiguration DecodeClientToken(string clientToken)
        {
            var decodedString = EncodingUtilities.FromBase64String(clientToken);
            var clientConfiguration = JsonConvert.DeserializeObject<BraintreeClientConfiguration>(decodedString);

            return clientConfiguration;
        }
    }
}
