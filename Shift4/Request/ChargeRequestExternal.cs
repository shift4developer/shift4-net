using Newtonsoft.Json;
using System;

namespace Shift4.Request
{
    public class ChargeRequestExternal : BaseRequest
    {
        [JsonProperty("schemeTransactionId")]
        public String SchemeTransactionId { get; set; }

        [JsonProperty("transactionLinkId")]
        public String TransactionLinkId { get; set; }

        [JsonProperty("vendorReference")]
        public String VendorReference { get; set; }

        [JsonProperty("networkToken")]
        public ExternalNetworkTokenRequest NetworkToken { get; set; }
    }
}
