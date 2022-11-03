using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Shift4.Enums
{
    public enum FileUploadPurpose
    {
        [EnumMember(Value = "dispute_evidence")]
        DisputeEvidence,

        //Used when received value can't be mapped to this enumeration.
        Unrecognized
    }
}
