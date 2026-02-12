using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum LiabilityShift
    {
        [EnumMember(Value = "successful")]
        Successful,

        [EnumMember(Value = "failed")]
        Failed,

        [EnumMember(Value = "not_possible")]
        NotPossible,

        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "bypassed")]
        Bypassed,

	    // Used when received value can't be mapped to this enumeration.
	    Unrecognized
    }
}
