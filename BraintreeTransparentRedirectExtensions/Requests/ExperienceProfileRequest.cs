using Newtonsoft.Json;

namespace BraintreeRedirectExtensions.Utilities
{
    internal class ExperienceProfileRequest
    {
        [JsonProperty("noShipping")]
        public bool NoShipping { get; set; }
    }
}