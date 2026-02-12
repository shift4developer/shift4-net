using Newtonsoft.Json;
using System;

namespace Shift4.Request
{
    public class PaymentMethodListRequest : ListRequest
    {
        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }

        [JsonProperty("customerId")]
        public String CustomerId { get; set; }
    }
}
