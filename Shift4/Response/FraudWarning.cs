using Newtonsoft.Json;
using Shift4.Converters;
using System;

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
