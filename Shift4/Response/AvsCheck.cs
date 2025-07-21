using Newtonsoft.Json;

namespace Shift4.Response
{
    public class AvsCheck : BaseResponse
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("cardholder")]
        public string Cardholder { get; set; }
    }
}
