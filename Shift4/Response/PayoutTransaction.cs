using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;
using System;
using System.Collections.Generic;

namespace Shift4.Response
{
    public class PayoutTransaction : BaseResponse
    {
       [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public PayoutTransactionType Type { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("fee")]
        public int? Fee { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("source")]
        [JsonConverter(typeof(ExpandableConverter<BaseResponse>))]
        public Expandable<BaseResponse> Source { get; set; }

        [JsonProperty("payout")]
        public string Payout { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("exchangeRate")]
        public double? ExchangeRate { get; set; }
    }
}

