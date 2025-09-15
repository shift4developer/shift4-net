using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum AdviceCode
    {

        [EnumMember(Value = "do_not_try_again")]
        DoNotTryAgain,

        /**
         * Used when received value can't be mapped to this enumeration.
         */
        Unrecognized
    }
}
