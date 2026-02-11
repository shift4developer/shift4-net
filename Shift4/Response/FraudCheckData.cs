using Newtonsoft.Json;
using System;

namespace Shift4.Response
{
    public class FraudCheckData : BaseResponse
    {

        [JsonProperty("ipCountry")]
        public String IpCountry { get; set; }

        [JsonProperty("ipAddress")]
        public String IpAddress { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("userAgent")]
        public String UserAgent { get; set; }

        [JsonProperty("acceptLanguage")]
        public String AcceptLanguage { get; set; }

    }
}
