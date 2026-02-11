using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum CardType
    {
        [EnumMember(Value = "Credit Card")]
        CreditCard,

        [EnumMember(Value = "Debit Card")]
        DebitCard,

        [EnumMember(Value = "Prepaid Card")]
        PrepaidCard,

        Unknown,

        //Used when received value can't be mapped to this enumeration.
        Unrecognized
    }
}
