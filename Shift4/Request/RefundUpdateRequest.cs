using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace Shift4.Request
{
    public class RefundUpdateRequest : BaseRequest
    {
        [JsonIgnore]
        public String RefundId { get;  set; }
        
        [JsonProperty("metadata")]
        public Dictionary<String, String> Metadata { get; set; }

    }
}
