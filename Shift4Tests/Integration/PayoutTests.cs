using Xunit;
using Shift4.Common;
using Shift4.Enums;
using Shift4.Exception;
using Shift4.Request;
using Shift4Tests.ModelBuilders;
using Shift4.Response;
using Shift4Tests.Units.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shift4Tests.Utils;

namespace Shift4Tests.Integration
{
    public class PayoutTests : IntegrationTest
    {
        [Fact]
        public async Task RetrievePayout()
        {
            // given
            var payout = await _gateway.CreatePayout();
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
                    {"key" , "value"}
                }
            });

            // when
            payout = await _gateway.CreatePayout();
            // then
            payout = await _gateway.RetrievePayout(payout.Id);
            Assert.True(payout.Amount > 0);
            Assert.NotNull(payout.PeriodStart);
            Assert.NotNull(payout.PeriodEnd);
            Assert.NotNull(payout.Created);

            var listedPayout = (await _gateway.ListPayouts()).List[0];
            Assert.Equal(payout.Id, listedPayout.Id);
            Assert.Equal(payout.Created, listedPayout.Created);
            Assert.Equal(payout.PeriodStart, listedPayout.PeriodStart);
            Assert.Equal(payout.PeriodEnd, listedPayout.PeriodEnd);
            Assert.Equal(payout.Amount, listedPayout.Amount);
            Assert.Equal(payout.Currency, listedPayout.Currency);
        }

        [Fact]
        public async Task CreateOnePayoutWithIdempotencyKey()
        {
            // given
            var payout = await _gateway.CreatePayout();
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
                    {"key" , "value"}
                }
            });

            var requestOptions = new RequestOptions
            {
                IdempotencyKey = TestUtils.IdempotencyKey()
            };

            // when
            payout = await _gateway.CreatePayout(requestOptions);
            var samePayout = await _gateway.CreatePayout(requestOptions);

            // then
            Assert.Equal(payout.Id, samePayout.Id);
        }

        [Fact]
        public async Task RetrievePayoutTransactions(){
            // given
            var payout = await _gateway.CreatePayout();
            var charge = await _gateway.CreateCharge(new ChargeRequest()
                {
                    Amount = 100,
                    Currency = "EUR",
                    Card = new CardRequest()
                    {
                        Number = "4242424242424242",
                        ExpMonth = "12",
                        ExpYear = "2033"
                    }
                });
            payout = await _gateway.CreatePayout();
            //when
            var payoutTransactions = await _gateway.ListPayoutTransactions(new PayoutTransactionListRequest() { Payout = payout.Id } );
            // then
            Assert.NotNull(payoutTransactions);
            Assert.True(payoutTransactions.List.Count > 3);

            var chargePayoutTransaction = await _gateway.ListPayoutTransactions(new PayoutTransactionListRequest() { Source = charge.Id });
            Assert.NotNull(chargePayoutTransaction);
            Assert.True(chargePayoutTransaction.List.Count == 1);
            var chargeTransaction = chargePayoutTransaction.List[0];
            Assert.False(chargePayoutTransaction.HasMore);
            Assert.Equal(chargeTransaction.Type, PayoutTransactionType.Charge);
            Assert.True(chargeTransaction.Amount > 0);
            Assert.Equal(chargeTransaction.Created, charge.Created);
            Assert.Equal(chargeTransaction.Description, charge.Description);
            Assert.Equal(chargeTransaction.Source, charge.Id);
            Assert.True(chargeTransaction.Fee > 0);
            Assert.NotNull(chargeTransaction.Id);
        }
    }
}
