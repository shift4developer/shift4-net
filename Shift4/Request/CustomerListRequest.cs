using Newtonsoft.Json;

namespace Shift4.Request
{
    public class CustomerListRequest : ListRequest
    {
        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("metadataKey")]
        public string MetadataKey { get; set; }

        [JsonProperty("metadataValue")]
        public string MetadataValue { get; set; }
    }
}
