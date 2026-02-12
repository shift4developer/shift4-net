using Newtonsoft.Json;

namespace Shift4.Request
{
    public class FraudWarningListRequest : ListRequest
    {
        [JsonProperty("chargeId")]
        public string ChargeId { get; set; }
        
        [JsonProperty("actionable")]
        public bool? Actionable { get; set; }
    }
}
