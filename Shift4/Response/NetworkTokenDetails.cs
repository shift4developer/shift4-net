using Newtonsoft.Json;
using System;

namespace Shift4.Response
{
    public class NetworkTokenDetails : BaseResponse
    {
        [JsonProperty("wasTokenUsed")]
        public bool WasTokenUsed { get; set; }

        [JsonProperty("tokenFirst6")]
        public String TokenFirst6 { get; set; }

        [JsonProperty("tokenLast4")]
        public String TokenLast4 { get; set; }
    }
}
