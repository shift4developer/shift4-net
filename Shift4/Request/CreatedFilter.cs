using Newtonsoft.Json;
using Shift4.Converters;
using System;

namespace Shift4.Request
{
    public class CreatedFilter
    {
        /// <summary>
        /// return objects created after given timestamp
        /// </summary>
        [JsonProperty("gt")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? Gt { get; set; }

        /// <summary>
        /// return objects created after or exactly on given timestamp
        /// </summary>
        [JsonProperty("gte")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? Gte { get; set; }

        /// <summary>
        ///  return objects created before given timestamp
        /// </summary>
        [JsonProperty("lt")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? Lt { get; set; }

        /// <summary>
        /// return objects created before or exactly on given timestamp
        /// </summary>
        [JsonProperty("lte")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? Lte { get; set; }
    }
}
