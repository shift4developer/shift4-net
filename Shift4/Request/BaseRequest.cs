using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Shift4.Request
{
    public class BaseRequest
    {
        [JsonExtensionData]
        public IDictionary<string, JToken> Other;
    }
}
