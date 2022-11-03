using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shift4.Common;
using Shift4.Converters;
using System;
using System.Collections.Generic;
namespace Shift4.Request
{
    public class SubscriptionRequest : BaseRequest
    {
        [JsonProperty("customerId")]
        public String CustomerId { get; set; }

        [JsonProperty("planId")]
        public String PlanId { get; set; }

        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        [JsonProperty("trialEnd")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? TrialEnd { get; set; }

        [JsonProperty("card")]
        public CardRequest Card { get; set; }

        [JsonProperty("captureCharges")]
        public bool? CaptureCharges { get; set; }

        [JsonProperty("shipping")]
        public Shipping Shipping { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<String, String> Metadata { get; set; }

    }
}
