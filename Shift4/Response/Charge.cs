﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Shift4.Common;
using Shift4.Converters;
using Shift4.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Response
{
    public class Charge : BaseResponse
    {

        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("clientObjectId")]
        public String ClientObjectId { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("amountRefunded")]
        public int AmountRefunded { get; set; }

        [JsonProperty("currency")]
        public String Currency { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public ChargeStatus Status { get; set; }

        [JsonProperty("card")]
        public Card Card { get; set; }

        [JsonProperty("paymentMethod")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty("flow")]
        public ChargeFlow Flow { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("subscriptionId")]
        public string SubscriptionId { get; set; }

        [JsonProperty("merchantAccountId")]
        public string MerchantAccountId { get; set; }

        [JsonProperty("captured")]
        public Boolean Captured { get; set; }

        [JsonProperty("refunded")]
        public Boolean Refunded { get; set; }

        [JsonProperty("refunds")]
        public List<Refund> Refunds { get; set; }

        [JsonProperty("disputed")]
        public bool Disputed { get; set; }

        [JsonProperty("dispute")]
        public Dispute Dispute { get; set; }

        [JsonProperty("fraudDetails")]
        public FraudDetails FraudDetails { get; set; }

        [JsonProperty("failureCode")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public ErrorCode FailureCode { get; set; }

        [JsonProperty("failureMessage")]
        public string FailureMessage { get; set; }

        [JsonProperty("failureIssuerDeclineCode")]
        public string FailureIssuerDeclineCode { get; set; }

        [JsonProperty("shipping")]
        public Shipping Shipping { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }

        [JsonProperty("threeDSecureInfo")]
        public ThreeDSecureInfo ThreeDSecureInfo { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<String, String> Metadata { get; set; }

    }
}


