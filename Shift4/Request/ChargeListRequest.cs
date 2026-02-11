using Newtonsoft.Json;
using System;

namespace Shift4.Request
{
    public class ChargeListRequest : ListRequest
    {
        [JsonProperty("customerId")]
        public String CustomerId { get; set; }
    }
}
