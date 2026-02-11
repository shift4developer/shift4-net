using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum DisputeReason
    {
        [EnumMember(Value = "FRAUDULENT")]
        Fraudulent,

        [EnumMember(Value = "UNRECOGNIZED")]
        Unrecognized,

        [EnumMember(Value = "DUPLICATE")]
        Duplicate,

        [EnumMember(Value = "SUBSCRIPTION_CANCELED")]
        SubscriptionCanceled,

        [EnumMember(Value = "PRODUCT_NOT_RECEIVED")]
        ProductNotReceived,

        [EnumMember(Value = "PRODUCT_UNACCEPTABLE")]
        ProductUnacceptable,

        [EnumMember(Value = "CREDIT_NOT_PROCESSED")]
        CreditNotProcessed,

        [EnumMember(Value = "GENERAL")]
        General,
    }
}
