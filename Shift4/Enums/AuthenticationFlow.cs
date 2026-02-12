using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum AuthenticationFlow
    {
        [EnumMember(Value="frictionless")]
        Frictionless,

        [EnumMember(Value="challenge")]
        Challenge,

        // Used when received value can't be mapped to this enumeration.
        Unrecognized

    }
}
