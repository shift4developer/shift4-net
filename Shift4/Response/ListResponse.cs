using Newtonsoft.Json;
using System.Collections.Generic;

namespace Shift4.Response
{
    public class ListResponse<T>{

    
        [JsonProperty("list")]
        public List<T> List { get; set; }

        [JsonProperty("totalCount")]
        public int? TotalCount { get; set; }

        [JsonProperty("hasMore")]
        public bool HasMore { get; set; }
    }
}
