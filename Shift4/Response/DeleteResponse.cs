using Newtonsoft.Json;

namespace Shift4.Response
{
    public class DeleteResponse : BaseResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}