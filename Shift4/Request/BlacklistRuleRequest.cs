using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;
using System;

namespace Shift4.Request
{
    public class BlacklistRuleRequest : BaseRequest
    {
        [JsonProperty("ruleType")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public BlacklistRuleType RuleType { get; set; }

        [JsonProperty("fingerprint")]
        public String Fingerprint { get; set; }

        [JsonProperty("ipAddress")]
        public String IpAddress { get; set; }

        [JsonProperty("ipCountry")]
        public String IpCountry { get; set; }

        [JsonProperty("metadataKey")]
        public String MetadataKey { get; set; }

        [JsonProperty("metadataValue")]
        public String MetadataValue { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("userAgent")]
        public String UserAgent { get; set; }

        [JsonProperty("acceptLanguage")]
        public String AcceptLanguage { get; set; }

        [JsonProperty("cardCountry")]
        public String CardCountry { get; set; }

        [JsonProperty("cardBin")]
        public String CardBin { get; set; }

        [JsonProperty("cardIssuer")]
        public String CardIssuer { get; set; }

    }
}
