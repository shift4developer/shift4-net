using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;
using System;

namespace Shift4.Response
{
    public class PaymentMethodApplePay : BaseResponse
    {

        [JsonProperty("cardBrand")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public CardBrand? CardBrand { get; set; }

        [JsonProperty("cardType")]
        [JsonConverter(typeof(SafeEnumConverter))]
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



