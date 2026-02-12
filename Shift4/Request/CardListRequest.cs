using Newtonsoft.Json;
using System;

namespace Shift4.Request
{
    public class CardListRequest : ListRequest
    {
        [JsonIgnore]
        public String CustomerId { get; set; }

        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }
    }
}
