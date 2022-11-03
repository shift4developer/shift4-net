using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Shift4.Converters;
using Shift4.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Response
{
    public class FraudDetails
    {

        [JsonProperty("status")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public FraudStatus Status { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }
}
