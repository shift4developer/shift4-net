using Newtonsoft.Json;
using Shift4.Enums;

namespace Shift4.Response
{
    public class AniCheck : BaseResponse
    {
        [JsonProperty("result")]
        public AniCheckResult Result { get; set; }
    }
}
