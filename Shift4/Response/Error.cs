using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Response
{
    public class Error
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public ErrorType Type { get; set; }

        [JsonProperty("code")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public ErrorCode? Code { get; set; }

        [JsonProperty("issuerDeclineCode")]
        public string IssuerDeclineCode { get; set; }

        [JsonProperty("chargeId")]
        public string ChargeId { get; set; }

        [JsonProperty("creditId")]
        public string CreditId { get; set; }

        [JsonProperty("blacklistRuleId")]
        public string BlacklistRuleId { get; set; }

        [JsonProperty("adviceCode")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public AdviceCode? AdviceCode { get; set; }

        [JsonProperty("networkAdviceCode")]
        public string NetworkAdviceCode { get; set; }
    }
}
