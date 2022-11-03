using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Shift4.Enums
{

    public enum Interval
    {
        [EnumMember(Value = "day")]
        Day,
        [EnumMember(Value = "week")]
        Week,
        [EnumMember(Value = "month")]
        Month,
        [EnumMember(Value = "year")]
        Year,

	    // Used when received value can't be mapped to this enumeration.
	    Unrecognized
    }

}