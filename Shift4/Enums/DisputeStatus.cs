using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum DisputeStatus
    {
        [EnumMember(Value = "RETRIEVAL_REQUEST_NEW")]
        NewRetrievalRequest,

        [EnumMember(Value = "RETRIEVAL_REQUEST_REPRESENTED")]
        RetrievalRequestRepresented,

        [EnumMember(Value = "CHARGEBACK_NEW")]
        NewChargeback,

        [EnumMember(Value = "RETRIEVAL_REQUEST_RESPONSE_UNDER_REVIEW")]
        RetrievalRequestResponseUnderReview,

        [EnumMember(Value = "CHARGEBACK_RESPONSE_UNDER_REVIEW")]
        ChargebackResponseUnderReview,

        [EnumMember(Value = "CHARGEBACK_REPRESENTED_SUCCESSFULLY")]
        ChargebackRepresentedSuccessfully,

        [EnumMember(Value = "CHARGEBACK_REPRESENTED_UNSUCCESSFULLY")]
        ChargebackRepresentedUnsuccessfully,

        [EnumMember(Value = "CHARGEBACK_REPRESENTED_PARTIALLY")]
        ChargebackRepresentedPartially,

        [EnumMember(Value = "CHARGEBACK_PREVENTED")]
        ChargebackPrevented,

	    // Used when received value can't be mapped to this enumeration.
	    Unrecognized
    }
}
