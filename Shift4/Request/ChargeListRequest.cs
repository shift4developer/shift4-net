﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Request
{
    public class ChargeListRequest : ListRequest
    {
        [JsonProperty("customerId")]
        public String CustomerId { get; set; }
    }
}
