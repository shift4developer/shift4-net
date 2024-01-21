using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;
using System;
using System.Collections.Generic;
namespace Shift4.Request
{
    public class RefundRequest : BaseRequest
    {
        [JsonProperty("chargeId")]
        public String ChargeId { get;  set; }

        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("reason")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public RefundReason? Reason { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<String, String> Metadata { get; set; }

    }
}
