using Newtonsoft.Json;
using System;

namespace Shift4.Request
{
    public class SubscriptionListRequest : ListRequest
    {
        [JsonProperty("customerId")]
        public String CustomerId { get; set; }

        [JsonProperty("planId")]
        public String PlanId { get; set; }

        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }
    }
}
