using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Shift4.Enums
{
    public enum CvvCheckResult
    {
        [EnumMember(Value = "match")]
        Match,

        [EnumMember(Value = "no_match")]
        NoMatch,

        [EnumMember(Value = "not_verified")]
        NotVerified,

        [EnumMember(Value = "not_provided")]
        NotProvided,

        [EnumMember(Value = "not_supported")]
        NotSupported,

        //Used when received value can't be mapped to this enumeration.
        Unrecognized
    }
}
