using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;
using System;

namespace Shift4.Response
{
    public class ChargeFlow : BaseResponse
    {
        [JsonProperty("nextAction")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public ChargeFlowActionType NextAction;

        [JsonProperty("redirect")]
        public ChargeFlowRedirect Redirect;

        [JsonProperty("returnUrl")]
        public String ReturnUrl;
    }
    
    public class ChargeFlowRedirect : BaseResponse
    {
        [JsonProperty("redirectUrl")]
        public String RedirectUrl;
    }
}


