using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum BlacklistRuleType
    {
        [EnumMember(Value = "fingerprint")]
        Fingerprint,

        [EnumMember(Value = "shipping")]
        Shipping,

        [EnumMember(Value = "ip_address")]
        IpAddress,

        [EnumMember(Value = "ip_country")]
        IpCountry,

        [EnumMember(Value = "metadata")]
        Metadata,

        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "email_domain")]
        EmailDomain,

        [EnumMember(Value = "user_agent")]
        UserAgent,

        [EnumMember(Value = "accept_language")]
        AcceptLanguage,

        [EnumMember(Value = "card_country")]
        CardCountry,

        [EnumMember(Value = "card_bin")]
        CardBin,

        [EnumMember(Value = "card_issuer")]
        CardIssuer,


        //Used when received value can't be mapped to this enumeration.
        [EnumMember(Value = "unrecognized")]
        Unrecognized
    }
}
