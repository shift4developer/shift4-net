using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum SubscriptionStatus
    {
        [EnumMember(Value = "trialing")]
        Trialing,

        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "past_due")]
        PastDue,

        [EnumMember(Value = "canceled")]
        Canceled,

        [EnumMember(Value = "unpaid")]
        Unpaid,

        [EnumMember(Value = "incomplete")]
        Incomplete,

	    // Used when received value can't be mapped to this enumeration.
	    Unrecognized
    }
}
