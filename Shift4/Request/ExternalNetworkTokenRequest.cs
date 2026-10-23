using Newtonsoft.Json;
using System;

namespace Shift4.Request
{
    public class ExternalNetworkTokenRequest : BaseRequest
    {
        [JsonProperty("token")]
        public String Token { get; set; }

        [JsonProperty("eci")]
        public String Eci { get; set; }

        [JsonProperty("cryptogram")]
        public String Cryptogram { get; set; }

        [JsonProperty("expiryMonth")]
        public String ExpiryMonth { get; set; }

        [JsonProperty("expiryYear")]
        public String ExpiryYear { get; set; }
    }
}
