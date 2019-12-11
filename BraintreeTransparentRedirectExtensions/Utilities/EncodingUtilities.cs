using System;
using System.Text;

namespace BraintreetRedirectExtensions.Utilities
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
