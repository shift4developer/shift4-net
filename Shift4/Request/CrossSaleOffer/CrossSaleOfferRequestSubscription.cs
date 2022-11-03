using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Request.CrossSaleOffer
{
    public class CrossSaleOfferRequestSubscription : BaseRequest
    {
        [JsonProperty("planId")]
        public string PlanId { get; set; }

        [JsonProperty("captureCharges")]
        public bool? CaptureCharges { get; set; }
    }
}
