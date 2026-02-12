using Newtonsoft.Json;
using System;

namespace Shift4.Request
{
    public class SubscriptionCancelRequest : BaseRequest
    {
        [JsonIgnore]
        public String SubscriptionId;

        [JsonProperty("atPeriodEnd")]
        public bool? AtPeriodEnd;

    }
}
