using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Shift4.Enums
{
    public enum CardType
    {
        [EnumMember(Value = "Credit Card")]
        CreditCard,

        [EnumMember(Value = "Debit Card")]
        DebitCard,

        Unknown,

        //Used when received value can't be mapped to this enumeration.
        Unrecognized
    }
}
