using Newtonsoft.Json;
using System;

namespace Shift4.Response
{
    public class ChargeExternal : BaseResponse
    {
        [JsonProperty("schemeTransactionId")]
        public String SchemeTransactionId { get; set; }

        [JsonProperty("transactionLinkId")]
        public String TransactionLinkId { get; set; }

        [JsonProperty("vendorReference")]
        public String VendorReference { get; set; }
    }
}
