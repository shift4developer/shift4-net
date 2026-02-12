using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;
using System;

namespace Shift4.Request
{
    public class ThreeDSecureExternal
    {

        [JsonProperty("version")]
		public String Version { get; set; }

        [JsonProperty("xid")]
		public String Xid { get; set; }

        [JsonProperty("eci")]
		public String Eci { get; set; }

        [JsonProperty("authenticationValue")]
		public String AuthenticationValue { get; set; }

        [JsonProperty("dsTransactionId")]
		public String DsTransactionId { get; set; }

        [JsonProperty("acsTransactionId")]
		public String AcsTransactionId { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(SafeEnumConverter))]
		public ThreeDSecureExternalStatus Status { get; set; }
    }
}
