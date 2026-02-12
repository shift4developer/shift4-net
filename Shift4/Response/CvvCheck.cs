using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;

namespace Shift4.Response
{
    public class CvvCheck : BaseResponse
    {
        [JsonProperty("result")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public CvvCheckResult Result { get; set; }
    }
}
