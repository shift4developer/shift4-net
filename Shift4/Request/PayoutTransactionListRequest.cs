using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shift4.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Shift4.Request
{
    public class PayoutTransactionListRequest : ListRequest
    {
       [JsonProperty("payout")]
        public String Payout { get; set; }

       [JsonProperty("source")]
        public String Source { get; set; }

        [JsonProperty("expand")]
        [JsonConverter(typeof(ExpandConverter))]
        public Expand Expand { get; }

        public PayoutTransactionListRequest() {
            Expand = new Expand();
        }

        public PayoutTransactionListRequest expandSource() {
            this.Expand.add("source");
            return this;
        }
    }
}
