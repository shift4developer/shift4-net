using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shift4.Converters;
using Shift4.Enums;
using Shift4.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Response
{
    public class PaymentMethodApplePay : BaseResponse
    {

        [JsonProperty("cardBrand")]
        public CardBrand? CardBrand { get; set; }

        [JsonProperty("cardType")]
        public CardType? CardType { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public String Currency { get; set; }

        [JsonProperty("first6")]
        public String First6 { get; set; }

        [JsonProperty("last4")]
        public String Last4 { get; set; }
    }
}



