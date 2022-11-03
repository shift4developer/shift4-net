using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Shift4.Internal
{
    public interface IHttpClient
    {
        System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> SendAsync(System.Net.Http.HttpRequestMessage request);
        void SetAuthorizationHeader(AuthenticationHeaderValue headerValue);
        void AddHeader(string name, string value);
    }
}
