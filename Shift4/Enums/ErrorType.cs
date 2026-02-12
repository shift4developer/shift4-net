using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum ErrorType
    {
        [EnumMember(Value = "invalid_request")]
        InvalidRequest,

        [EnumMember(Value = "card_error")]
        CardError,

        [EnumMember(Value = "gateway_error")]
        GatewayError,

        [EnumMember(Value = "rate_limit_error")]
        RateLimitError,

        // Used when received value can't be mapped to this enumeration.
        Unrecognized
    }
}
