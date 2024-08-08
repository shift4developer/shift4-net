using Xunit;
using Shift4.Common;
using Shift4.Enums;
using Shift4.Exception;
using Shift4.Request;
using Shift4Tests.ModelBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shift4Tests.Utils;

namespace Shift4Tests.Integration
{
    public class RefundTests : IntegrationTest
    {
        [Fact]
        public async Task CreateRefund()
        {
            // given
            var charge = await _gateway.CreateCharge(new ChargeRequest()
            {
                Amount = 100,
                Currency = "USD",
                Card = new CardRequest()
                {
                    Number = "4242424242424242",
                    ExpMonth = "12",
                    ExpYear = "2033"
                }
            });
            // when
            var refund = await _gateway.CreateRefund(new RefundRequest()
            {
                ChargeId = charge.Id,
                Amount = 30,
                Metadata = new Dictionary<string, string>
                {
                    {"key" , "value"}
                }
            });
            // then
            charge = await _gateway.RetrieveCharge(charge.Id);
            Assert.Equal(charge.Id, refund.Charge);
            Assert.Equal(30, charge.AmountRefunded);
            Assert.NotNull(refund.Id);
            Assert.Single(refund.Metadata);
            Assert.Equal("value", refund.Metadata["key"]);
        }

        [Fact]
        public async Task CreateRefundOnlyOnceWithIdempotencyKey()
        {
            // given
            var charge = await _gateway.CreateCharge(new ChargeRequest()
            {
                Amount = 100,
                Currency = "USD",
                Card = new CardRequest()
                {
                    Number = "4242424242424242",
                    ExpMonth = "12",
                    ExpYear = "2033"
                }
            });
            // when
            var refundRequest = new RefundRequest()
            {
                ChargeId = charge.Id,
                Amount = 30,
                Metadata = new Dictionary<string, string>
                {
                    {"key" , "value"}
                }
            };
            var requestOptions = RequestOptions.WithIdempotencyKey(TestUtils.IdempotencyKey());

            var refund = await _gateway.CreateRefund(refundRequest, requestOptions);
            var sameRefund = await _gateway.CreateRefund(refundRequest, requestOptions);

            // then
            Assert.Equal(refund.Id, sameRefund.Id);
        }

        [Fact]
        public async Task RetriveRefund()
        {
            // given
            var charge = await _gateway.CreateCharge(new ChargeRequest()
            {
                Amount = 100,
                Currency = "USD",
                Card = new CardRequest()
                {
                    Number = "4242424242424242",
                    ExpMonth = "12",
                    ExpYear = "2033"
                }
            });
            // when
            var refund = await _gateway.CreateRefund(new RefundRequest()
            {
                ChargeId = charge.Id,
                Amount = 30,
                Metadata = new Dictionary<string, string>
                {
                    {"key" , "value"}
                }
            });
            var retrivedRefund = await _gateway.RetrieveRefund(refund.Id);
            // then
            Assert.Equal(refund.Id, retrivedRefund.Id);
            Assert.Equal(refund.Amount, retrivedRefund.Amount);
            Assert.Equal(refund.Created, retrivedRefund.Created);
            Assert.Equal("value", retrivedRefund.Metadata["key"]);
        }

        [Fact]
        public async Task UpdateRefund()
        {
            // given
            var charge = await _gateway.CreateCharge(new ChargeRequest()
            {
                Amount = 100,
                Currency = "USD",
                Card = new CardRequest()
                {
                    Number = "4242424242424242",
                    ExpMonth = "12",
                    ExpYear = "2033"
                }
            });
            var refund = await _gateway.CreateRefund(new RefundRequest()
            {
                ChargeId = charge.Id,
                Amount = 30,
                Metadata = new Dictionary<string, string>
                {
                    {"key1" , "value1"}
                }
            });
            // when
            var updatedRefund = await _gateway.UpdateRefund(new RefundUpdateRequest()
            {
                RefundId = refund.Id,
                Metadata = new Dictionary<string, string>
                {
                    {"key2" , "value2"}
                }
            });
            // then
            Assert.Single(refund.Metadata);
            Assert.Equal("value1", refund.Metadata["key1"]);
            Assert.DoesNotContain("key2", (IDictionary<string, string>)refund.Metadata);

            Assert.Equal(refund.Id, updatedRefund.Id);
            Assert.Single(updatedRefund.Metadata);
            Assert.DoesNotContain("key1", (IDictionary<string, string>)updatedRefund.Metadata);
            Assert.Equal("value2", updatedRefund.Metadata["key2"]);
        }
    }
}
