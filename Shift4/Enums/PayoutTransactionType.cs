using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Shift4.Enums
{
    public enum PayoutTransactionType
    {
        [EnumMember(Value="charge")]
        Charge,
        [EnumMember(Value="refund")]
        Refund,
        [EnumMember(Value="credit")]
        Credit,
        [EnumMember(Value="chargeback")]
        Chargeback,
        [EnumMember(Value="chargeback_represented")]
        ChargebackRepresented,
        [EnumMember(Value="adjustment")]
        Adjustment,
        [EnumMember(Value="reserve_withhold")]
        ReserveWithhold,
        [EnumMember(Value="reserve_release")]
        ReserveRelease,
        [EnumMember(Value="acquirer_fee")]
        AcquirerFee,
        // Used when received value can't be mapped to this enumeration.
        Unrecognized

    }
}
