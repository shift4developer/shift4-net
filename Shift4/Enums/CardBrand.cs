using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum CardBrand
    {
        Visa,

        [EnumMember(Value="American Express")]
        AmericanExpress,

        MasterCard,

        Maestro,

        Discover,

        JCB,

        [EnumMember(Value="Diners Club")]

        DinersClub,

        Unknown,

        // Used when received value can't be mapped to this enumeration.
        Unrecognized

    }
}
