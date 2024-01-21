using Xunit;
using Shift4.Enums;
using Shift4.Exception;
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
        public class FlowsTest : IntegrationTest
    {
        private CustomerRequestBuilder _customerRequestBuilder = new CustomerRequestBuilder();
        private CardRequestBuilder _cardRequestBuilder = new CardRequestBuilder();
        private TokenRequestBuilder _tokenRequestBuilder = new TokenRequestBuilder();
        private ChargeRequestBuilder _chargeRequestBuilder = new ChargeRequestBuilder();
        private PlanRequestBuilder _planRequestBuilder = new PlanRequestBuilder();

        /// <summary>
        /// test for flow Token -> Charge -> Capture -> Refund
        /// </summary>
        [Fact]
        public async Task ChargeCaptureRefundFlowTest()
        {
            try
            {
                var createTokenRequest = _tokenRequestBuilder.Build();
                var token = await _gateway.CreateToken(createTokenRequest);
                token = await _gateway.RetrieveToken(token.Id);

                var chargeRequest = _chargeRequestBuilder.WithCard(_cardRequestBuilder.WithId(token.Id))
                                                         .WithIsCaptured(false)
                                                         .Build();
                var charge = await _gateway.CreateCharge(chargeRequest);

                var capture = new CaptureRequest() { ChargeId = charge.Id };
                charge = await _gateway.CaptureCharge(capture);

                var refund = new RefundRequest() { ChargeId = charge.Id, Amount = 500 };
                await _gateway.CreateRefund(refund);

                charge = await _gateway.RetrieveCharge(charge.Id);

                Assert.True(charge.Captured);
                Assert.True(charge.Refunded);
                Assert.Single(charge.Refunds);
                Assert.Equal(500, charge.Refunds.First().Amount);
                Assert.Equal(500, charge.AmountRefunded);
                Assert.Equal(chargeRequest.Amount, charge.Amount);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }

        }


        /// <summary>
        /// test for flow Token -> Charge -> Customer -> Charge (existing card)
        /// </summary>
        [Fact]
        public async Task ChargeCustomerFromChargeFlowTest()
        {
            try
            {
                var createTokenRequest = _tokenRequestBuilder.Build();
                var token = await _gateway.CreateToken(createTokenRequest);
                token = await _gateway.RetrieveToken(token.Id);

                var chargeRequest = _chargeRequestBuilder.WithCard(_cardRequestBuilder.WithId(token.Id)).Build();
                var charge = await _gateway.CreateCharge(chargeRequest);

                var customerRequest = _customerRequestBuilder.WithCard(_cardRequestBuilder.WithId(charge.Id)).Build(); 
                var customer = await _gateway.CreateCustomer(customerRequest);

                var chargeRequest2 = new ChargeRequestBuilder().WithCustomerId(customer.Id).Build();
                charge = await _gateway.CreateCharge(chargeRequest2);

                Assert.Equal(chargeRequest2.Amount, charge.Amount);
                Assert.Equal(customer.Id, charge.CustomerId);

            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        /// <summary>
        /// test for flow Plan -> Customer -> Token -> Subscription
        /// </summary>
        [Fact]
        public async Task SubscribeWithTokenTest()
        {
            try
            {
                var plan = await _gateway.CreatePlan(_planRequestBuilder.Build());

                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var createTokenRequest = _tokenRequestBuilder.Build();
                var token = await _gateway.CreateToken(createTokenRequest);


                var subscriptionRequest = new SubscriptionRequest() { CustomerId = customer.Id, PlanId = plan.Id, Card = new CardRequest() { Id = token.Id } };
                var subscription = await _gateway.CreateSubscription(subscriptionRequest);

                Assert.Equal(plan.Id, subscription.PlanId);
                Assert.Equal(customer.Id, subscription.CustomerId);

            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        /// <summary>
        /// test for flow Customer -> Charge -> Charge (existing card)
        /// </summary>
        [Fact]
        public async Task ChargeCustomerTwiceTest()
        {
            try
            {
                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var chargeRequest = _chargeRequestBuilder.WithCard(_cardRequestBuilder)
                                                         .WithCustomerId(customer.Id)
                                                         .Build();

                var charge = await _gateway.CreateCharge(chargeRequest);

                var chargeRequest2 = new ChargeRequest() { Amount = 1000, Currency = chargeRequest.Currency, CustomerId = charge.CustomerId };
                var charge2 = await _gateway.CreateCharge(chargeRequest2);

                Assert.Equal(1000, charge2.Amount);
                Assert.Equal(customer.Id, charge2.CustomerId);

            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        /// <summary>
        /// test for flow Customer -> Add card -> Charge card
        /// </summary>
        [Fact]
        public async Task ChargeCardTest()
        {
            try
            {
                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var cardRequest = _cardRequestBuilder.WithCustomerId(customer.Id).Build();
                var card = await _gateway.CreateCard(cardRequest);

                card = await _gateway.RetrieveCard(customer.Id, card.Id);

                Assert.Equal(cardRequest.GetLast4(), card.Last4);
                Assert.Equal(cardRequest.ExpMonth, card.ExpMonth);
                Assert.Equal(cardRequest.ExpYear, card.ExpYear);
                Assert.Equal(cardRequest.CardholderName, card.CardholderName);

                var chargeRequest = _chargeRequestBuilder.WithCustomerId(customer.Id)
                                                        .Build();
                var charge =await _gateway.CreateCharge(chargeRequest);

                Assert.Equal(chargeRequest.Amount, charge.Amount);
                
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

    }
}
