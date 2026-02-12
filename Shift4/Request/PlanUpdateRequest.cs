using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace Shift4.Request
{
    public class PlanUpdateRequest : BaseRequest
    {
        [JsonIgnore]
        public string PlanId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public int? Amount { get; set; }

        /// <summary>
        /// Currency ISO code
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<String, String> Metadata { get; set; }
    }
}
