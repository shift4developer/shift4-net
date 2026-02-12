using Newtonsoft.Json;

namespace Shift4.Request
{
    public class PaymentMethodApplePayRequest : BaseRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
