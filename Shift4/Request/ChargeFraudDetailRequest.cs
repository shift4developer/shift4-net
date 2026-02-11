using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;

namespace Shift4.Request
{
    public class ChargeFraudDetailRequest : BaseRequest
    {
        [JsonProperty("status")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public FraudStatus Status { get; set; }

    }
}
