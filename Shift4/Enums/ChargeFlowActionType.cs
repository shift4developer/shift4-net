using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Shift4.Enums
{
    public enum  ChargeFlowActionType
    {
        [EnumMember(Value = "redirect")]
        Redirect,

        [EnumMember(Value = "wait")]
        Wait,

        [EnumMember(Value = "none")]
        None,

	    // Used when received value can't be mapped to this enumeration.
	    Unrecognized
    }
}
