using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shift4.Common;
using Shift4.Enums;
using System;
using System.Collections.Generic;
namespace Shift4.Request
{
    public class ChargeFraudDetailRequest : BaseRequest
    {
        [JsonProperty("status")]
        public FraudStatus Status { get; set; }

    }
}
