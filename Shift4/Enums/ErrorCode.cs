using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum ErrorCode
    {

        [EnumMember(Value = "amount_too_high")]
        AmountTooHigh,

        [EnumMember(Value = "amount_too_low")]
        AmountTooLow,

        [EnumMember(Value = "invalid_number")]
        InvalidNumber,

        [EnumMember(Value = "invalid_expiry_month")]
        InvalidExpiryMonth,

        [EnumMember(Value = "invalid_expiry_year")]
        InvalidExpiryYear,

        [EnumMember(Value = "invalid_cvc")]
        InvalidCvc,

        [EnumMember(Value = "incorrect_cvc")]
        IncorrectCvc,

        [EnumMember(Value = "incorrect_zip")]
        IncorrectZip,

        [EnumMember(Value = "incorrect_address")]
        IncorrectAddress,

        [EnumMember(Value = "expired_card")]
        ExpiredCard,

        [EnumMember(Value = "insufficient_funds")]
        InsufficientFunds,

        [EnumMember(Value = "lost_or_stolen")]
        LostOrStolen,

        [EnumMember(Value = "suspected_fraud")]
        SuspectedFraud,

        [EnumMember(Value = "card_declined")]
        CardDeclined,

        [EnumMember(Value = "brand_not_supported")]
        BrandNotSupported,

        [EnumMember(Value = "currency_not_supported")]
        CurrencyNotSupported,

        [EnumMember(Value = "processing_error")]
        ProcessingError,

        [EnumMember(Value = "blacklisted")]
        Blacklisted,

        [EnumMember(Value = "authentication_required")]
        AuthenticationRequired,

        [EnumMember(Value = "blocked")]
        Blocked,

        [EnumMember(Value = "call_issuer")]
        CallIssuer,

        [EnumMember(Value = "do_not_try_again")]
        DoNotTryAgain,

        [EnumMember(Value = "closed_account")]
        ClosedAccount,

        [EnumMember(Value = "expired_token")]
        ExpiredToken,

        [EnumMember(Value = "limit_exceeded")]
        LimitExceeded,

        [EnumMember(Value = "payment_method_declined")]
        PaymentMethodDeclined,

        [EnumMember(Value = "invalid_account")]
        InvalidAccount,

        [EnumMember(Value = "offline_mode")]
        OfflineMode,

        [EnumMember(Value = "offline_mode_transaction_amount_exceeded_limit")]
        OfflineModeTransactionAmountExceededLimit,

        [EnumMember(Value = "offline_mode_max_amount_exceeded_limit")]
        OfflineModeMaxAmountExceededLimit,
        /**
         * Used when received value can't be mapped to this enumeration.
         */
        Unrecognized
    }
}
