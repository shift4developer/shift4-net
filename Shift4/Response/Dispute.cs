using Newtonsoft.Json;
using Shift4.Common;
using Shift4.Converters;
using Shift4.Enums;
using System;

namespace Shift4.Response
{
    public class Dispute : BaseResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("updated")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime Updated { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("Status")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public DisputeStatus Status { get; set; }

        [JsonProperty("reason")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public DisputeReason Reason { get; set; }

        [JsonProperty("acceptedAsLost")]
        public bool AcceptedAsLost { get; set; }

        [JsonProperty("charge")]
        public Charge Charge { get; set; }

        [JsonProperty("evidence")]
        public DisputeEvidence Evidence{ get; set; }

        [JsonProperty("evidenceDetails")]
        public DisputeEvidenceDetails EvidenceDetails { get; set; }
    }
}
