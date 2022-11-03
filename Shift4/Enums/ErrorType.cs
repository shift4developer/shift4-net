using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Shift4.Enums
{
    public enum ErrorType
    {
        [EnumMember(Value = "invalid_request")]
        InvalidRequest,

        [EnumMember(Value = "card_error")]
        CardError,

        [EnumMember(Value = "gateway_error")]
        GatewayError,

	    // Used when received value can't be mapped to this enumeration.
	    Unrecognized
    }
}
