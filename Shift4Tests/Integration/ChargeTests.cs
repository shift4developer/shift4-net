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
    public class ChargeTests : IntegrationTest
    {
        private AddressBuilder _addressBuilder = new AddressBuilder();
        private CustomerRequestBuilder _customerRequestBuilder = new CustomerRequestBuilder();
        private CardRequestBuilder _cardRequestBuilder = new CardRequestBuilder();
        private ChargeRequestBuilder _chargeRequestBuilder = new ChargeRequestBuilder();

        /// <summary>
        /// charge amount exceeds the available fund or the card's credit limit.
        /// </summary>
        [Fact]
        public async Task ChargeCardWithInsufficientFoundsTest()
        {
            try
            {
                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var chargeRequest = _chargeRequestBuilder.WithCustomerId(customer.Id).WithCard(_cardRequestBuilder).Build();
                var charge = await _gateway.CreateCharge(chargeRequest);

            }
            catch (Shift4Exception exc)
            {
                Assert.Equal(ErrorCode.InsufficientFunds, exc.Error.Code);
            }
        }

        /// <summary>
        /// charge card with wrong number
        /// </summary>
        [Fact]
        public async Task ChargeCardWithWrongNumberTest()
        {
            try
            {
                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var chargeRequest = _chargeRequestBuilder.WithCustomerId(customer.Id).WithCard(_cardRequestBuilder.WithWrongNumber()).Build(); 
                var charge = await _gateway.CreateCharge(chargeRequest);

            }
            catch (Shift4Exception exc)
            {
                Assert.Equal(ErrorCode.InvalidNumber, exc.Error.Code);
            }
        }

        /// <summary>
        /// charge existing card provided by cardId
        /// </summary>
        [Fact]
        public async Task ChargeCardByIdTest()
        {

            var customerRequest = _customerRequestBuilder.Build();
            var customer = await _gateway.CreateCustomer(customerRequest);

            var cardRequest = _cardRequestBuilder.WithCustomerId(customer.Id).Build();
            var card = await _gateway.CreateCard(cardRequest);

            var chargeRequest = _chargeRequestBuilder.WithCustomerId(customer.Id).WithCard(_cardRequestBuilder.WithId(card.Id)).Build();
            var charge = await _gateway.CreateCharge(chargeRequest);

            Assert.Equal(2000, charge.Amount);
            Assert.Equal(card.Id, charge.Card.Id);
        }

        /// <summary>
        /// create only one card and charge existing card provided by cardId only once
        /// </summary>
        [Fact]
        public async Task CreateOneCardAndChargeCardByIdOnlyOnceBecauseIdempotencyTest()
        {

            var customerRequest = _customerRequestBuilder.Build();
            var customer = await _gateway.CreateCustomer(customerRequest);

            var cardRequestOption = new RequestOptions().WithIdempotencyKey(TestUtils.IdempotencyKey());
            var cardRequest = _cardRequestBuilder.WithCustomerId(customer.Id).Build();
            var card = await _gateway.CreateCard(cardRequest, cardRequestOption);
            var sameCard = await _gateway.CreateCard(cardRequest, cardRequestOption);

            var chargeRequest = _chargeRequestBuilder.WithCustomerId(customer.Id).WithCard(_cardRequestBuilder.WithId(card.Id)).Build();
            var chargeRequestOption = new RequestOptions().WithIdempotencyKey(TestUtils.IdempotencyKey());
            var charge = await _gateway.CreateCharge(chargeRequest, chargeRequestOption);
            var sameCharge = await _gateway.CreateCharge(chargeRequest, chargeRequestOption);

            Assert.Equal(2000, charge.Amount);
            Assert.Equal(card.Id, charge.Card.Id);
            Assert.Equal(card.Id, sameCard.Id);
            Assert.Equal(charge.Id, sameCharge.Id);
        }

        /// <summary>
        /// charge existing card provided by cardId
        /// </summary>
        [Fact]
        public async Task ChargeWithShippingAndBillingTest()
        {
            var address = _addressBuilder.Build();

            var customerRequest = _customerRequestBuilder.Build();
            var customer = await _gateway.CreateCustomer(customerRequest);

            var cardRequest = _cardRequestBuilder.WithCustomerId(customer.Id).Build();
            var card = await _gateway.CreateCard(cardRequest);

            var chargeRequest = _chargeRequestBuilder.WithCustomerId(customer.Id)
                                                     .WithCard(_cardRequestBuilder.WithId(card.Id))
                                                     .WithShipping()
                                                     .WithBilling()
                                                     .Build();

            var charge = await _gateway.CreateCharge(chargeRequest);

            Assert.Equal(chargeRequest.Shipping.Name, charge.Shipping.Name);
            Assert.Equal(chargeRequest.Billing.Name, charge.Billing.Name);
        }

        /// <summary>
        /// charge existing card provided by cardId
        /// </summary>
        [Fact]
        public async Task ForceToUseThreeDSecureTest()
        {
            try
            {
                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var chargeRequest = _chargeRequestBuilder.WithCustomerId(customer.Id)
                                                         .With3DSecure(new ThreeDSecure() { RequireAttempt = true })
                                                         .WithCard(_cardRequestBuilder.WithCustomerId(customer.Id))
                                                         .Build();
                var charge = await _gateway.CreateCharge(chargeRequest);
            }
            catch (Shift4Exception exc)
            {
                Assert.Equal("3D Secure attempt is required.", exc.Error.Message);
            }
        }
    }
}
