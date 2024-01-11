using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Shift4.Enums
{
    public enum ChargeType
    {
        [EnumMember(Value="first_recurring")]
        FirstRecurring,

        [EnumMember(Value="subsequent_recurring")]
        SubsequentRecurring,

        [EnumMember(Value="merchant_initiated")]
        MerchantInitiated,

        [EnumMember(Value="customer_initiated")]
        CustomerInitiated,

        // Used when received value can't be mapped to this enumeration.
        Unrecognized

    }
}
