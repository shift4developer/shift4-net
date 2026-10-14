using Newtonsoft.Json;
using Shift4.Request;
using Shift4.Request.Checkout;
using Shift4.Response;
using System.Collections.Generic;
using Xunit;

namespace Shift4Tests.Units
{
    public class LargeAmountTests
    {
        private const long AboveIntMax = 3000000000L;

        [Fact]
        public void TestChargeRequestSerializesAmountAboveIntMax()
        {
            var json = JsonConvert.SerializeObject(new ChargeRequest() { Amount = AboveIntMax, Currency = "EUR" });

            Assert.Contains("\"amount\":3000000000", json);
        }

        [Fact]
        public void TestRefundRequestSerializesAmountAboveIntMax()
        {
            var json = JsonConvert.SerializeObject(new RefundRequest() { ChargeId = "char_1", Amount = AboveIntMax });

            Assert.Contains("\"amount\":3000000000", json);
        }

        [Fact]
        public void TestCheckoutRequestSerializesAmountsAboveIntMax()
        {
            var json = JsonConvert.SerializeObject(new CheckoutRequestCustomCharge()
            {
                AmountOptions = new List<long> { AboveIntMax, AboveIntMax + 1 },
                CustomAmount = new CustomAmount() { Min = AboveIntMax, Max = AboveIntMax + 2 }
            });

            Assert.Contains("\"amountOptions\":[3000000000,3000000001]", json);
            Assert.Contains("\"min\":3000000000", json);
            Assert.Contains("\"max\":3000000002", json);
        }

        [Fact]
        public void TestChargeDeserializesAmountsAboveIntMax()
        {
            var charge = JsonConvert.DeserializeObject<Charge>("{\"id\":\"char_1\",\"amount\":3000000000,\"amountRefunded\":2500000000}");

            Assert.Equal(AboveIntMax, charge.Amount);
            Assert.Equal(2500000000L, charge.AmountRefunded);
        }

        [Fact]
        public void TestRefundDeserializesAmountAboveIntMax()
        {
            var refund = JsonConvert.DeserializeObject<Refund>("{\"id\":\"ref_1\",\"amount\":3000000000}");

            Assert.Equal(AboveIntMax, refund.Amount);
        }

        [Fact]
        public void TestPayoutTransactionDeserializesFeeAboveIntMax()
        {
            var transaction = JsonConvert.DeserializeObject<PayoutTransaction>("{\"amount\":3000000000,\"fee\":3000000001}");

            Assert.Equal(AboveIntMax, transaction.Amount);
            Assert.Equal(3000000001L, transaction.Fee);
        }
    }
}
