using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum  ChargeFlowActionType
    {

        [EnumMember(Value = "app_redirect")]
        AppRedirect,

        [EnumMember(Value = "qr_code")]
        QrCode,

        [EnumMember(Value = "mobile_app_confirmation")]
        MobileAppConfirmation,

        [EnumMember(Value = "redirect")]
        Redirect,

        [EnumMember(Value = "wait")]
        Wait,

        [EnumMember(Value = "none")]
        None,

	    // Used when received value can't be mapped to this enumeration.
	    Unrecognized
    }
}
