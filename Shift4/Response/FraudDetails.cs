using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;

namespace Shift4.Response
{
    public class FraudDetails
    {

        [JsonProperty("status")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public FraudStatus Status { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }
}
