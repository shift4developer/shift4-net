using Newtonsoft.Json;
using System.Collections.Generic;

namespace Shift4.Response
{
    public class Shift4List
    {

        [JsonProperty("list")]
        public List<object> List { get; set; }

        [JsonProperty("totalCount")]
        public int? TotalCount { get; set; }

    }
}
