using Newtonsoft.Json;
using System;

namespace Shift4.Request
{
    public class ChargeFlowRequest : BaseRequest
    {
        [JsonProperty("returnUrl")]    
        public String ReturnUrl { get; set; }

    }
}
