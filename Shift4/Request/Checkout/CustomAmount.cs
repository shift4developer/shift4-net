using Newtonsoft.Json;

namespace Shift4.Request.Checkout
{
    public class CustomAmount
    {
        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }
    }
}
