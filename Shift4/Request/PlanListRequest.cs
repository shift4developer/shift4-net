﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Request
{
    public class PlanListRequest : ListRequest
    {
        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }
    }
}
