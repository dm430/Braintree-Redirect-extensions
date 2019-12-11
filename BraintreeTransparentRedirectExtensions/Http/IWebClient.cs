using System.Net;

namespace BraintreetRedirectExtensions
{
    public interface IWebClient
    {
        WebHeaderCollection Headers { get; }

        string UploadString(string endpoint, string data);
    }
}
