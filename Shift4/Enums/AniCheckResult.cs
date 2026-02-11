using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum AniCheckResult
    {
        [EnumMember(Value = "full_match")]
        FullMatch,

        [EnumMember(Value = "partial_match")]
        PartialMatch,

        [EnumMember(Value = "no_match")]
        NoMatch,

        [EnumMember(Value = "not_verified")]
        NotVerified,

        [EnumMember(Value = "not_supported")]
        NotSupported,

        //Used when received value can't be mapped to this enumeration.
        Unrecognized
    }
}
