using System.Runtime.Serialization;

namespace Shift4.Enums
{
    public enum PaymentMethodType
    {
        [EnumMember(Value = "ach")]
        Ach,

        [EnumMember(Value = "alipay")]
        Alipay,

        [EnumMember(Value = "apple_pay")]
        ApplePay,

        [EnumMember(Value = "bancontact")]
        Bancontact,

        [EnumMember(Value = "bitpay")]
        BitPay,

        [EnumMember(Value = "blik")]
        Blik,

        [EnumMember(Value = "boleto")]
        Boleto,

        [EnumMember(Value = "eps")]
        Eps,

        [EnumMember(Value = "estonianbanks")]
        Estonianbanks,

        [EnumMember(Value = "giropay")]
        Giropay,

        [EnumMember(Value = "google_pay")]
        GooglePay,

        [EnumMember(Value = "ideal")]
        Ideal,

        [EnumMember(Value = "klarna_debit_risk")]
        KlarnaDebitRisk,

        [EnumMember(Value = "latvianbanks")]
        Latvianbanks,

        [EnumMember(Value = "lithuanianbanks")]
        Lithuanianbanks,

       [EnumMember(Value = "maxima")]
        Maxima,

        [EnumMember(Value = "multibanco")]
        Multibanco,

        [EnumMember(Value = "mybank")]
        Mybank,

        [EnumMember(Value = "p24")]
        P24,

        [EnumMember(Value = "paypost")]
        Paypost,

        [EnumMember(Value = "paysafecard")]
        Paysafecard,

        [EnumMember(Value = "paysafecash")]
        Paysafecash,

        [EnumMember(Value = "paysera")]
        Paysera,

        [EnumMember(Value = "payu")]
        Payu,

        [EnumMember(Value = "perlas")]
        Perlas,

        [EnumMember(Value = "poli")]
        Poli,

        [EnumMember(Value = "skrill")]
        Skrill,

        [EnumMember(Value = "sofort")]
        Sofort,

        [EnumMember(Value = "swish")]
        Swish,

        [EnumMember(Value = "trustly")]
        Trustly,

        [EnumMember(Value = "unionpay")]
        Unionpay,

        [EnumMember(Value = "verkkopankki")]
        Verkkopankki,

        [EnumMember(Value = "wechatpay")]
        Wechatpay,

	    // Used when received value can't be mapped to this enumeration.
	    Unrecognized
    }
}
