using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Shift4.Enums
{
    public enum  CrossSaleOfferTemplate
    {
        [EnumMember(Value = "image_and_text")]
        ImageAndText,

        [EnumMember(Value = "text_only")]
        TextOnly,

	    // Used when received value can't be mapped to this enumeration.
	    Unrecognized
    }
}
