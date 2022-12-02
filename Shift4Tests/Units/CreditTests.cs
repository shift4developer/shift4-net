using Xunit;
using Shift4.Request;
using Shift4.Response;
using Shift4Tests.ModelBuilders;
using Shift4Tests.Units.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shift4Tests.Units
{
        public class CreditTests : BaseUnitTestsSet
    {
        private CardRequestBuilder _cardRequestBuilder = new CardRequestBuilder();

        [Fact]
        public async Task CreateCreditTest()
        {
            var requestTester = GetRequestTester();
            var customerId = "1";
            var creditRequest = new CreditRequest() { CustomerId = customerId, Card = _cardRequestBuilder.WithId("1").Build(), Amount=100,Currency="EUR"};
            await requestTester.TestMethod<Credit>(
                async (api) =>
                {
                    await api.CreateCredit(creditRequest);
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Post,
                    Action = "credits",
                    Parameter = creditRequest
                }
            );
        }

        [Fact]
        public async Task CreateCreditWithCardTest()
        {
            var requestTester = GetRequestTester();
            var customerId = "1";
            var creditRequest = new CreditRequest()
            {
                CustomerId = customerId,
                Card = _cardRequestBuilder.Build(),
                Amount = 100,
                Currency = "EUR"
            };
            await requestTester.TestMethod<Credit>(
                async (api) =>
                {
                    await api.CreateCredit(creditRequest);
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Post,
                    Action = "credits",
                    Parameter = creditRequest
                }
            );
        }

        [Fact]
        public async Task RetrieveCreditTest()
        {
            var requestTester = GetRequestTester();
            var creditId = "1";
            await requestTester.TestMethod<Credit>(
                async (api) =>
                {
                    await api.RetrieveCredit(creditId);
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Get,
                    Action = string.Format("credits/{0}", creditId),
                    Parameter = null
                }
            );
        }

        [Fact]
        public async Task UpdateCreditTest()
        {
            var requestTester = GetRequestTester();
            var creditId = "1";
            var updateCreditRequest = new CreditUpdateRequest() { CreditId = creditId, Description = "new description" };

            await requestTester.TestMethod<Credit>(
                async (api) =>
                {
                    await api.UpdateCredit(updateCreditRequest);
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Post,
                    Action = string.Format("credits/{0}", creditId),
                    Parameter = updateCreditRequest
                }
            );
        }

        [Fact]
        public async Task ListCreditsTest()
        {
            var requestTester = GetRequestTester();

            await requestTester.TestMethod<Shift4List>(
                async (api) =>
                {
                    await api.ListCredits();
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Get,
                    Action = "credits",
                    Parameter = null
                }
            );
        }
    }
}
