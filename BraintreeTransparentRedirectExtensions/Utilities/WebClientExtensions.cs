using Newtonsoft.Json;
using System.Net;

namespace BraintreeRedirectExtensions.Utilities
{
    internal static class WebClientExtensions
    {
        public static TResponse Post<TResponse, TRequest>(this IWebClient webClient, string endpoint, TRequest request)
        {
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";

            var objectJson = JsonConvert.SerializeObject(request);
            var jsonResponse = webClient.UploadString(endpoint, objectJson);
            var response = JsonConvert.DeserializeObject<TResponse>(jsonResponse);

            return response;
        }
    }
}
