using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Shift4.Enums
{
    public enum RefundReason
    {
        [EnumMember(Value="fraudulent")]
        Fraudulent,

        // Used when received value can't be mapped to this enumeration.
        Unrecognized

    }
}
