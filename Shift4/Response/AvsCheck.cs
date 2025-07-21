using Newtonsoft.Json;
using Shift4.Enums;

namespace Shift4.Response
{
    public class AvsCheck : BaseResponse
    {
        [JsonProperty("result")]
        public AvsCheckResult Result { get; set; }
    }
}
