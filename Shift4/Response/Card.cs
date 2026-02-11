using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;
using System;

namespace Shift4.Response
{
    public class Card : BaseResponse
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("first6")]
        public String First6 { get; set; }

        [JsonProperty("last4")]
        public String Last4 { get; set; }

        [JsonProperty("expMonth")]
        public String ExpMonth { get; set; }

        [JsonProperty("expYear")]
        public String ExpYear { get; set; }

        [JsonProperty("cardholderName")]
        public String CardholderName { get; set; }

        [JsonProperty("customerId")]
        public String CustomerId { get; set; }

        [JsonProperty("merchantAccountId")]
        public string MerchantAccountId { get; set; }

        [JsonProperty("brand")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public CardBrand Brand { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public CardType Type { get; set; }

        [JsonProperty("country")]
        public String Country { get; set; }

        [JsonProperty("issuer")]
        public String Issuer { get; set; }

        [JsonProperty("addressLine1")]
        public String AddressLine1 { get; set; }

        [JsonProperty("addressLine2")]
        public String AddressLine2 { get; set; }

        [JsonProperty("addressCity")]
        public String AddressCity { get; set; }

        [JsonProperty("addressZip")]
        public String AddressZip { get; set; }

        [JsonProperty("addressState")]
        public String AddressState { get; set; }

        [JsonProperty("addressCountry")]
        public String AddressCountry { get; set; }

        [JsonProperty("fingerprint")]
        public string Fingerprint { get; set; }

        [JsonProperty("fraudCheckData")]
        public FraudCheckData FraudCheckData { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

    }
}



