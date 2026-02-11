using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;
using Shift4.Common;
using System;

namespace Shift4.Response
{
    public class PaymentMethod : BaseResponse
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("clientObjectId")]
        public String ClientObjectId { get; set; }

        [JsonProperty("customerId")]
        public String CustomerId { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public PaymentMethodType Type { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public PaymentMethodStatus Status { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }

        [JsonProperty("fraudCheckData")]
        public FraudCheckData FraudCheckData { get; set; }

        [JsonProperty("applePay")]
        public PaymentMethodApplePay ApplePay { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}



