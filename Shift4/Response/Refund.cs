using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Response
{
    public class Refund : BaseResponse
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public String Currency { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("charge")]
        public String Charge { get; set; }

        [JsonProperty("reason")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public RefundReason Reason { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public RefundStatus Status { get; set; }
    }
}

