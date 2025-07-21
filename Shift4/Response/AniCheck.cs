using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Response
{
    public class AniCheck
    {
        [JsonProperty("result")]
        public AniCheckResult Result { get; set; }
    }
}
