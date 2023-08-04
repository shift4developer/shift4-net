using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shift4.Common;
using Shift4.Enums;
using Shift4.Converters;

namespace Shift4.Request
{
    public class PaymentMethodApplePayRequest : BaseRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
