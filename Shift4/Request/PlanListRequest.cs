using Newtonsoft.Json;

namespace Shift4.Request
{
    public class PlanListRequest : ListRequest
    {
        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }
    }
}
