using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum PaymentMethodStatus
    {
        [EnumMember(Value = "used")]
        Used,

        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "chargeable")]
        Chargeable,

        [EnumMember(Value = "failed")]
        Failed,

	    // Used when received value can't be mapped to this enumeration.
	    Unrecognized

    }
}
