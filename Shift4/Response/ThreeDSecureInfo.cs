using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;

namespace Shift4.Response
{
    public class ThreeDSecureInfo
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Currency ISO Code
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("enrolled")]
        public bool Enrolled { get; set; }

        [JsonProperty("liabilityShift")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public LiabilityShift LiabilityShift { get; set; }

        [JsonProperty("authenticationFlow")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public AuthenticationFlow AuthenticationFlow { get; set; }

    }
}
