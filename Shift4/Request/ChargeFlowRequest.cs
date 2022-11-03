using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shift4.Common;
using Shift4.Enums;
using System;
using System.Collections.Generic;


namespace Shift4.Request
{
    public class ChargeFlowRequest : BaseRequest
    {
        [JsonProperty("returnUrl")]    
        public String ReturnUrl { get; set; }

    }
}
