using Xunit;
using Shift4.Common;
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
        public class DisputeTests : BaseUnitTestsSet
    {
        [Fact]
        public async Task RetrieveDisputeTest()
        {
            var requestTester = GetRequestTester();
            var disputeId = "1";
         
            await requestTester.TestMethod<Dispute>(
                async (api) =>
                {
                    await api.RetrieveDispute(disputeId);
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Get,
                    Action = string.Format("disputes/{0}", disputeId),
                    Parameter = null
                }
            );
        }

        [Fact]
        public async Task UpdateDisputeTest()
        {
            var requestTester = GetRequestTester();
            var disputeId = "1";

            var updateRequest = new DisputeUpdateRequest() { DisputeId = disputeId ,Evidence=new DisputeEvidence()};

            await requestTester.TestMethod<Dispute>(
                async (api) =>
                {
                    await api.UpdateDispute(updateRequest);
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Post,
                    Action = string.Format("disputes/{0}", disputeId),
                    Parameter = updateRequest
                }
            );
        }

        [Fact]
        public async Task CloseDisputeTest()
        {
            var requestTester = GetRequestTester();
            var disputeId = "1";

            await requestTester.TestMethod<Dispute>(
                async (api) =>
                {
                    await api.CloseDispute(disputeId);
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Post,
                    Action = string.Format("disputes/{0}/close", disputeId),
                    Parameter = null
                }
            );
        }

        [Fact]
        public async Task ListDisputeTest()
        {
            var requestTester = GetRequestTester();

            await requestTester.TestMethod<Shift4List>(
                async (api) =>
                {
                    await api.ListDisputes();
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Get,
                    Action = "disputes",
                    Parameter = null
                }
            );
        }
    }
}
