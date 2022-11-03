using Xunit;
using Moq;
using Shift4;
using Shift4.Internal;
using Shift4.Request;
using Shift4.Response;
using Shift4Tests.Units.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shift4Tests.Units
{
        public class UploadTests : BaseUnitTestsSet
    {
        [Fact]
        public async Task RetrieveFileUploadTest()
        {
            var requestTester = GetRequestTester();
            var uploadId = "1";
            await requestTester.TestMethod<FileUpload>(
                async (api) =>
                {
                    await api.RetrieveFileUpload(uploadId);
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Get,
                    Action = string.Format("files/{0}", uploadId),
                    Parameter = null,
                    UseUploadEndpoint = true
                }
            );
        }

        [Fact]
        public async Task ListFileUploadTest()
        {
            var requestTester = GetRequestTester();
            await requestTester.TestMethod<Shift4List>(
                async (api) =>
                {
                    await api.ListFileUpload();
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Get,
                    Action = "files",
                    Parameter = null,
                    UseUploadEndpoint = true
                }
            );
        }

        [Fact]
        public async Task CreateFileUploadTest()
        {
            var apiClientMock = new Mock<IApiClient>();
            var signMock = new Mock<ISignService>();
            var configMock = new Mock<IConfigurationProvider>();
            configMock.Setup<string>(x => x.GetUploadsUrl()).Returns("https://example2.com");
            Shift4Gateway gateway = new Shift4Gateway(apiClientMock.Object, configMock.Object, signMock.Object);

            var request = new FileUploadRequest()
            {
                File = new byte[1] { 233 },
                FileName = "test.jpg",
                Purpose =  Shift4.Enums.FileUploadPurpose.DisputeEvidence
            };

            await gateway.CreateFileUpload(request);

            apiClientMock.Verify<Task<FileUpload>>(api => api.SendMultiPartRequest<FileUpload>(
                    It.Is<HttpMethod>(method => method == HttpMethod.Post),
                    It.Is<string>(action => action == configMock.Object.GetUploadsUrl() + "/files"),
                    It.Is<Dictionary<string, string>>(dictionary => dictionary.Any(p => p.Key == "purpose" && p.Value == "dispute_evidence")),
                    It.Is<byte[]>(array => array[0] == 233),
                    It.Is<string>(f=>f=="test.jpg"))
                , Times.Once);
        }
    }
}
