using Newtonsoft.Json;
using Shift4.Enums;

namespace Shift4.Response
{
    public class CvvCheck : BaseResponse
    {
        [JsonProperty("result")]
        public CvvCheckResult Result { get; set; }
    }
}
