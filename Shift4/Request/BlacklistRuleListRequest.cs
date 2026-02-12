using Newtonsoft.Json;

namespace Shift4.Request
{
    public class BlacklistRuleListRequest : ListRequest
    {
        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }
    }
}
