using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Shift4.Request
{
    public class CustomerRequest : BaseRequest
    {
        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("card")]
        public CardRequest Card { get; set; }

        [JsonProperty("paymentMethod")]
        public PaymentMethodRequest PaymentMethod { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<String, String> Metadata { get; set; }

    }
}
