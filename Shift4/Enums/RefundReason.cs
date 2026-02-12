using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum RefundReason
    {
        [EnumMember(Value="fraudulent")]
        Fraudulent,

        [EnumMember(Value="expired")]
        Expired,

        // Used when received value can't be mapped to this enumeration.
        Unrecognized

    }
}
