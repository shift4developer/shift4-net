using Xunit;
using Shift4.Common;
using Shift4.Enums;
using Shift4.Request;
using Shift4.Response;
using Shift4Tests.ModelBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shift4Tests.Utils;

namespace Shift4Tests.Integration
{
    public class PaymentMethodTests : IntegrationTest
    {
        private CustomerRequestBuilder _customerRequestBuilder = new CustomerRequestBuilder();

        [Fact]
        public async Task CreateAndRetrievePaymentMethodTest()
        {
            // given
            var request = CreatePaymentMethodRequest();
            // when
            var created = await _gateway.CreatePaymentMethod(request);
            var retrieved = await _gateway.RetrievePaymentMethod(created.Id);
            // then
            Assert.Equal(created.Id, retrieved.Id);
            Assert.Equal(created.ClientObjectId, retrieved.ClientObjectId);
            Assert.Equal(request.Type, retrieved.Type);
            Assert.Equal(request.Billing.Name, retrieved.Billing.Name);
            Assert.Equal(PaymentMethodStatus.Chargeable, retrieved.Status);
        }

        [Fact]
        public async Task CreatePaymentMethodOnlyOnceWithIdempotencyKeyTest()
        {
            // given
            var request = CreatePaymentMethodRequest();
            var requestOptions = new RequestOptions
            {
                IdempotencyKey = TestUtils.IdempotencyKey()
            };

            // when
            var created = await _gateway.CreatePaymentMethod(request, requestOptions);
            var sameCreated = await _gateway.CreatePaymentMethod(request, requestOptions);

            // then
            Assert.Equal(created.Id, sameCreated.Id);
        }

        [Fact]
        public async Task CreateApplePayPaymentMethodTest()
        {
            // given
            var request = CreateApplePayPaymentMethodRequest();
            // when
            var created = await _gateway.CreatePaymentMethod(request);
            // then
            Assert.Equal(PaymentMethodType.ApplePay, created.Type);
            Assert.Equal(100, created.ApplePay.Amount);
            Assert.Equal("EUR", created.ApplePay.Currency);
            Assert.NotNull(created.ApplePay.CardBrand);
            Assert.NotNull(created.ApplePay.CardType);
            Assert.NotNull(created.ApplePay.First6);
            Assert.NotNull(created.ApplePay.Last4);
        }

        [Fact]
        public async Task ListPaymentMethodsTest()
        {
            // given
            var customer = await _gateway.CreateCustomer(_customerRequestBuilder.Build());
            var request = CreatePaymentMethodRequest();
            request.CustomerId = customer.Id;
            var pm1 = await _gateway.CreatePaymentMethod(request);
            var pm2 = await _gateway.CreatePaymentMethod(request);
            var pm3 = await _gateway.CreatePaymentMethod(request);
            // when
            var listReqeust = new PaymentMethodListRequest()
            {
                CustomerId = customer.Id
            };
            var response = await _gateway.ListPaymentMethods(listReqeust);
            // then
            Assert.Equal(3, response.List.Count);
            Assert.Equal(pm3.Id, response.List[0].Id);
            Assert.Equal(pm2.Id, response.List[1].Id);
            Assert.Equal(pm1.Id, response.List[2].Id);
        }

        [Fact]
        public async Task DeletePaymentMethodTest()
        {
            // given
            var request = CreatePaymentMethodRequest();
            var created = await _gateway.CreatePaymentMethod(request);
            // when
            await _gateway.DeletePaymentMethod(created.Id);
            var retrieved = await _gateway.RetrievePaymentMethod(created.Id);
            // then
            Assert.False(created.Deleted);
            Assert.True(retrieved.Deleted);
        }

        private PaymentMethodRequest CreatePaymentMethodRequest()
        {
            return new PaymentMethodRequest()
            {
                Type = PaymentMethodType.Alipay,
                Billing = new Billing()
                {
                    Name = "Alice Cooper",
                    Address = new Address()
                    {
                        CountryISOCode = "CN"
                    }
                }
            };
        }

        private PaymentMethodRequest CreateApplePayPaymentMethodRequest()
        {
            return new PaymentMethodRequest()
            {
                Type = PaymentMethodType.ApplePay,
                ApplePay = new PaymentMethodApplePayRequest()
                {
                    Token = "TEST_TOKEN:100EUR"
                }
            };
        }
    }
}
