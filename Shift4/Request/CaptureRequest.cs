using Newtonsoft.Json;
using System;
namespace Shift4.Request
{
    public class CaptureRequest : BaseRequest
    {
        [JsonIgnore]
        public String ChargeId { get; set; }
    }
}
