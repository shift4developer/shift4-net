using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Shift4.Request
{
    public class CreditRequest : BaseRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("card")]
        public CardRequest Card { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }
        
        [JsonProperty("merchantAccountId")]
        public String MerchantAccountId { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<String, String> Metadata { get; set; }

    }
}
