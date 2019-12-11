using System.Net;

namespace BraintreeRedirectExtensions
{
    public interface IWebClient
    {
        WebHeaderCollection Headers { get; }

        string UploadString(string endpoint, string data);
    }
}
