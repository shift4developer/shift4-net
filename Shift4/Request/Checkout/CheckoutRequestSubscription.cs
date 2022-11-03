using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Request.Checkout
{
    public class CheckoutRequestSubscription
    {
        [JsonProperty("planId")]
        public string PlanId { get; set; }

        [JsonProperty("captureCharges")]
        public bool? CaptureCharges { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<String, String> Metadata { get; set; }
    }
}
