using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum AvsCheckResult
    {
        [EnumMember(Value = "full_match")]
        FullMatch,

        [EnumMember(Value = "partial_match")]
        PartialMatch,

        [EnumMember(Value = "no_match")]
        NoMatch,

        [EnumMember(Value = "not_provided")]
        NotProvided,

        [EnumMember(Value = "unavailable")]
        Unavailable,

        //Used when received value can't be mapped to this enumeration.
        Unrecognized
    }
}
