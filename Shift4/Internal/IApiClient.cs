using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Shift4.Request;

namespace Shift4
{
    public interface IApiClient
    {
        Task<T> SendRequest<T>(HttpMethod method, string url, object parameter);
        Task<T> SendRequest<T>(HttpMethod method, string url, object parameter, RequestOptions requestOptions);
        Task<T> SendMultiPartRequest<T>(HttpMethod method, string url, Dictionary<string, string> form, byte[] fileBody, string fileName);
    }
}
