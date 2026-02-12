using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum EventType
    {

        [EnumMember(Value = "CHARGE_PENDING")]
        ChargePending,
        [EnumMember(Value = "CHARGE_SUCCEEDED")]
        ChargeSucceeded,
        [EnumMember(Value = "CHARGE_FAILED")]
        ChargeFailed,
        [EnumMember(Value = "CHARGE_UPDATED")]
        ChargeUpdated,
        [EnumMember(Value = "CHARGE_CAPTURED")]
        ChargeCaptured,
        [EnumMember(Value = "CHARGE_REFUNDED")]
        ChargeRefunded,

        [EnumMember(Value = "REFUND_UPDATED")]
        RefundUpdated,

        [EnumMember(Value = "CHARGE_DISPUTE_CREATED")]
        ChargeDisputeCreated,
        [EnumMember(Value = "CHARGE_DISPUTE_UPDATED")]
        ChargeDisputeUpdated,
        [EnumMember(Value = "CHARGE_DISPUTE_WON")]
        ChargeDisputeWon,
        [EnumMember(Value = "CHARGE_DISPUTE_LOST")]
        ChargeDisputeLost,

        [EnumMember(Value = "CHARGE_DISPUTE_FUNDS_WITHDRAWN")]
        ChargeDisputeFundsWithdrawn,
        [EnumMember(Value = "CHARGE_DISPUTE_FUNDS_RESTORED")]
        ChargeDisputeFundsRestored,

        [EnumMember(Value = "CUSTOMER_CARD_CREATED")]
        CustomerCardCreated,
        [EnumMember(Value = "CUSTOMER_CARD_UPDATED")]
        CustomerCardUpdated,
        [EnumMember(Value = "CUSTOMER_CARD_DELETED")]
        CustomerCardDeleted,
        [EnumMember(Value = "CUSTOMER_CREATED")]
        CustomerCreated,
        [EnumMember(Value = "CUSTOMER_UPDATED")]
        CustomerUpdated,
        [EnumMember(Value = "CUSTOMER_DELETED")]
        CustomerDeleted,
        [EnumMember(Value = "CUSTOMER_SUBSCRIPTION_CREATED")]
        CustomerSubscriptionCreated,
        [EnumMember(Value = "CUSTOMER_SUBSCRIPTION_UPDATED")]
        CustomerSubscriptionUpdated,
        [EnumMember(Value = "CUSTOMER_SUBSCRIPTION_DELETED")]
        CustomerSubscriptionDeleted,

        [EnumMember(Value = "PLAN_CREATED")]
        PlanCreated,
        [EnumMember(Value = "PLAN_UPDATED")]
        PlanUpdated,
        [EnumMember(Value = "PLAN_DELETED")]
        PlanDeleted,
        
        [EnumMember(Value = "FRAUD_WARNING_CREATED")]
        FraudWarningCreated,
        [EnumMember(Value = "FRAUD_WARNING_UPDATED")]
        FraudWarningUpdated,

        [EnumMember(Value = "CREDIT_SUCCEEDED")]
        CreditSucceeded,
        [EnumMember(Value = "CREDIT_FAILED")]
        CreditFailed,
        [EnumMember(Value = "CREDIT_UPDATED")]
        CreditUpdated,

        [EnumMember(Value = "PAYMENT_METHOD_CREATED")]
        PaymentMethodCreated,
        [EnumMember(Value = "PAYMENT_METHOD_UPDATED")]
        PaymentMethodUpdated,
        [EnumMember(Value = "PAYMENT_METHOD_DELETED")]
        PaymentMethodDeleted,

        [EnumMember(Value = "PAYOUT_CREATED")]
        PayoutCreated,
        [EnumMember(Value = "PAYOUT_UPDATED")]
        PayoutUpdated,

        //Used when received value can't be mapped to this enumeration.
        Unrecognized
    }
}
