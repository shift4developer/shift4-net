using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
namespace Shift4.Request
{
    public class RefundRequest : BaseRequest
    {
        [JsonIgnore]
        public String ChargeId { get;  set; }

        [JsonProperty("amount")]
        public int? Amount { get; set; }

    }
}
