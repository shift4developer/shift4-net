using Newtonsoft.Json;
using Shift4.Common;

namespace Shift4.Request
{
    public class DisputeUpdateRequest : BaseRequest
    {
        [JsonIgnore]
        public string DisputeId { get; set; }

        [JsonProperty("evidence")]
        public DisputeEvidence Evidence { get; set; }
    }
}
