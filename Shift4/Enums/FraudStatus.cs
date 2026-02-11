using System.Runtime.Serialization;


namespace Shift4.Enums
{
    public enum FraudStatus
    {
        [EnumMember(Value = "in_progress")]
        InProgress,

        [EnumMember(Value = "safe")]
        Safe,

        [EnumMember(Value = "suspicious")]
        Suspicious,

        [EnumMember(Value = "fraudulent")]
        Fraudulent,

        [EnumMember(Value = "unavailable")]
        Unavailable,

        [EnumMember(Value = "unknown")]
        Unknown,

        //Used when received value can't be mapped to this enumeration.
        Unrecognized
    }
}
