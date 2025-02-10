using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shift4.Converters;
using Shift4.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Response
{
    public class FraudWarning : BaseResponse
    {

        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("charge")]
        public String Charge { get; set; }

        [JsonProperty("actionable")]
        public bool Actionable { get; set; }

    }
}
