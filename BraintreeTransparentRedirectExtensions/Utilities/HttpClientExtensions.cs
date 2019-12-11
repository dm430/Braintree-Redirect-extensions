using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BraintreeRedirectExtensions.Utilities
{
    internal static class HttpClientExtensions
    {
        internal static async Task<TResponse> PostAsync<TResponse, TRequest>(this HttpClient client, string endpoint, TRequest localPaymentRequest)
        {
            var result = await client.PostAsJsonAsync(endpoint, localPaymentRequest);

            if (!result.IsSuccessStatusCode)
            {
                var error = await result.Content.ReadAsStringAsync();
                throw new Exception(error);
            }

            return await result.Content.ReadAsAsync<TResponse>();
        }
    }
}
