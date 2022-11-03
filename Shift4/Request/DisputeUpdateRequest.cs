using Newtonsoft.Json;
using Shift4.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
