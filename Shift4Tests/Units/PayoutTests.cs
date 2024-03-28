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
        public class PayoutTests : BaseUnitTestsSet
    {

        [Fact]
        public async Task CreatePayoutTest()
        {
            var requestTester = GetRequestTester();
            await requestTester.TestMethod<Payout>(
                async (api) =>
                {
                    await api.CreatePayout();
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Post,
                    Action = "payouts",
                    Parameter = null
                }
            );
        }

        [Fact]
        public async Task RetrievePayoutTest()
        {
            var requestTester = GetRequestTester();
            var PayoutId = "1";
         
            await requestTester.TestMethod<Payout>(
                async (api) =>
                {
                    await api.RetrievePayout(PayoutId);
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Get,
                    Action = string.Format("payouts/{0}", PayoutId),
                    Parameter = null
                }
            );
        }

        [Fact]
        public async Task ListPayoutTest()
        {
            var requestTester = GetRequestTester();

            await requestTester.TestMethod<Shift4List>(
                async (api) =>
                {
                    await api.ListPayouts();
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Get,
                    Action = "payouts",
                    Parameter = null
                }
            );
        }
    }
}
