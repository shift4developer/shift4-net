using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Request.Checkout
{
    public class CheckoutRequestThreeDSecure
    {
        [JsonProperty("enable")]
        public bool Enable { get; set; }

        [JsonProperty("requireEnrolledCard")]
        public bool RequireEnrolledCard { get; set; }

        [JsonProperty("requireSuccessfulLiabilityShiftForEnrolledCard")]
        public bool? RequireSuccessfulLiabilityShiftForEnrolledCard { get; set; }
    }
}
