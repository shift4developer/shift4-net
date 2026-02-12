using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Shift4.Response
{
    public class BaseResponse
    {
        [JsonExtensionData]
        public IDictionary<string, JToken> Other;
    }
}
