using System;
using System.Text;

namespace BraintreeRedirectExtensions.Utilities
{
    public static class EncodingUtilities
    {
        public static string FromBase64String(string value)
        {
            var data = Convert.FromBase64String(value);

            return Encoding.UTF8.GetString(data);
        }
    }
}
