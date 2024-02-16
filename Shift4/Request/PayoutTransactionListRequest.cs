using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
    }
}
