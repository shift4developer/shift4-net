using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum ChargeStatus
    {
        [EnumMember(Value = "successful")]
        Successful,

        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value ="failed")]
        Failed,

	    // Used when received value can't be mapped to this enumeration.
	    Unrecognized
    }
}
