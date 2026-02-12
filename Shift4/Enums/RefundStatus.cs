using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum RefundStatus
    {
        [EnumMember(Value="successful")]
        Successful,

        [EnumMember(Value="failed")]
        Failed,

        [EnumMember(Value="pending")]
        Pending,

        // Used when received value can't be mapped to this enumeration.
        Unrecognized

    }
}
