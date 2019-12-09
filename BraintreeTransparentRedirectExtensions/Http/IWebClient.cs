using System.Net;

namespace BraintreeTransparentRedirectExtensions
{
    public interface IWebClient
    {
        WebHeaderCollection Headers { get; }

        string UploadString(string endpoint, string data);
    }
}
