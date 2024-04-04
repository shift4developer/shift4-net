using Newtonsoft.Json;
using Shift4.Exception;
using Shift4.Internal;
using Shift4.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Shift4
{
    public class ApiClient : IApiClient
    {
        private string _privateAuthToken;
        private IHttpClient _client;
        private IFileExtensionToMimeMapper _fileExtensionToMimeMapper;
        private string _sdkVersion = "3.6.0";

        public ApiClient(IHttpClient httpClient, ISecretKeyProvider secretKeyProvider, IFileExtensionToMimeMapper fileExtensionToMimeMapper)
        {
            var secretKey = secretKeyProvider.GetSecretKey();
            var tokenBytes = Encoding.UTF8.GetBytes(secretKey + ":");
            _privateAuthToken = Convert.ToBase64String(tokenBytes);
            _fileExtensionToMimeMapper = fileExtensionToMimeMapper;
            _client = httpClient;
            _client.SetAuthorizationHeader(new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", _privateAuthToken));
            _client.AddHeader("User-Agent", string.Format("Shift4-NET/{0}", _sdkVersion));
        }

        public async Task<T> SendRequest<T>(HttpMethod method, string url, object parameter)
        {

            HttpRequestMessage request = new HttpRequestMessage(method,url);
            if (parameter != null)
            {
                var requestJson = JsonConvert.SerializeObject(parameter, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                request.Content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var apiResponseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiResponseString);
            }
            else
            {
                ErrorResponse errorResponse;
                var apiErrorResponseString = await response.Content.ReadAsStringAsync();
                errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(apiErrorResponseString);
                throw new Shift4Exception(errorResponse.Error, typeof(T).Name, url);
            }
        }

        public async Task<T> SendMultiPartRequest<T>(HttpMethod method, string url,Dictionary<string,string> form,byte[] fileBody,string fileName)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, url);

            var content = new MultipartFormDataContent();
            foreach (var formEntry in form)
            {
                var stringContent = new StringContent(formEntry.Value);
                stringContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = string.Format("\"{0}\"",formEntry.Key)
                };
                content.Add(stringContent, formEntry.Key);
            }

            var fileContent = new ByteArrayContent(fileBody);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"file\"",
                FileName = string.Format("\"{0}\"",fileName)
            };

            var mimeType = _fileExtensionToMimeMapper.GetMimeType(fileName);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
            content.Add(fileContent);

 
            request.Content = content;

            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var apiResponseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiResponseString);
            }
            else
            {
                ErrorResponse errorResponse;
                var apiErrorResponseString = await response.Content.ReadAsStringAsync();
                errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(apiErrorResponseString);
                throw new Shift4Exception(errorResponse.Error, typeof(T).Name, url);
            }
        }
    }
}
