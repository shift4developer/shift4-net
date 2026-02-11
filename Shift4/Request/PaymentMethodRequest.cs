using Newtonsoft.Json;
using System;
using Shift4.Common;
using Shift4.Enums;
using Shift4.Converters;

namespace Shift4.Request
{
    public class PaymentMethodRequest : BaseRequest
    {

        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("customerId")]
        public String CustomerId { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public PaymentMethodType Type { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }


        [JsonProperty("applePay")]
        public PaymentMethodApplePayRequest ApplePay { get; set; }  
    }
}
