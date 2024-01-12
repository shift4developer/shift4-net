using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Shift4.Enums
{
    public enum LiabilityShift
    {
        [EnumMember(Value = "successful")]
        Successful,

        [EnumMember(Value = "failed")]
        Failed,

        [EnumMember(Value = "not_possible")]
        NotPossible,

        [EnumMember(Value = "pending")]
        Pending,

	    // Used when received value can't be mapped to this enumeration.
	    Unrecognized
    }
}
