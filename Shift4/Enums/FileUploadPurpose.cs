using System.Runtime.Serialization;

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
