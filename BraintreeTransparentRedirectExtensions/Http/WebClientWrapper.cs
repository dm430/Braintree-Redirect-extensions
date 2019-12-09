using System.Net;

namespace BraintreeTransparentRedirectExtensions.Http
{
    public class WebClientWrapper : IWebClient
    {
        private readonly WebClient webClient;

        public WebClientWrapper()
        {
            webClient = new WebClient();
        }

        public WebHeaderCollection Headers => webClient.Headers;

        public string UploadString(string endpoint, string data)
        {
            return webClient.UploadString(endpoint, data);
        }
    }
}
