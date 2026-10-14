using Newtonsoft.Json;

namespace Shift4.Request.Checkout
{
    public class CustomAmount
    {
        [JsonProperty("min")]
        public long Min { get; set; }

        [JsonProperty("max")]
        public long Max { get; set; }
    }
}
