using Newtonsoft.Json;

namespace Shift4.Request
{
    public class ThreeDSecure
    {
        [JsonProperty("requireAttempt")]
        public bool RequireAttempt { get; set; }

        [JsonProperty("requireEnrolledCard")]
        public bool RequireEnrolledCard { get; set; }

        [JsonProperty("requireSuccessfulLiabilityShiftForEnrolledCard")]
        public bool? RequireSuccessfulLiabilityShiftForEnrolledCard { get; set; }

        [JsonProperty("external")]
        public ThreeDSecureExternal External { get; set; }
    }
}
