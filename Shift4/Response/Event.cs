using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;
using System;

namespace Shift4.Response
{
    public class Event : BaseResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public EventType Type { get; set; }

        [JsonProperty("data")]
        [JsonConverter(typeof(EventDataConverter))]
        public object Data { get; set; }

        [JsonProperty("log")]
        public string Log { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime Created { get; set; }
    }
}