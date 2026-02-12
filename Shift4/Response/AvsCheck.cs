using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;

namespace Shift4.Response
{
    public class AvsCheck : BaseResponse
    {
        [JsonProperty("result")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public AvsCheckResult Result { get; set; }
    }
}
