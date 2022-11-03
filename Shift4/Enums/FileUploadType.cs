using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Shift4.Enums
{
    public enum FileUploadType
    {
        [EnumMember(Value = "jpg")]
        JPG,

        [EnumMember(Value = "pdf")]
        PDF,

        [EnumMember(Value = "png")]
        PNG,

        [EnumMember(Value = "csv")]
        CSV,

        // Used when received value can't be mapped to this enumeration.
        Unrecognized
    }
}
