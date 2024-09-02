using Xunit;
using Shift4.Common;
using Shift4.Enums;
using Shift4.Exception;
using Shift4.Request;
using Shift4Tests.ModelBuilders;
using System;
using System.Linq;
using System.Threading.Tasks;
using Shift4.Internal;
using Shift4Tests.Utils;

namespace Shift4Tests.Integration
{
        public class SubscriptionTests : IntegrationTest
    {
        CustomerRequestBuilder _customerRequestBuilder = new CustomerRequestBuilder();
        CardRequestBuilder _cardRequestBuilder = new CardRequestBuilder();
        ChargeRequestBuilder _chargeRequestBuilder = new ChargeRequestBuilder();
        PlanRequestBuilder _planRequestBuilder = new PlanRequestBuilder();
        UnixDateConverter unixDateConverter = new UnixDateConverter();

        [Fact]
        public async Task SubscribeWithNewCardTest()
        {
            try
            {
                var plan = await _gateway.CreatePlan(_planRequestBuilder.Build());

                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var cardRequest = _cardRequestBuilder.Build();
            
                var subscriptionRequest = new SubscriptionRequest() { CustomerId = customer.Id, PlanId = plan.Id,TrialEnd=DateTime.Now.AddDays(10), Card = cardRequest };
                var subscription = await _gateway.CreateSubscription(subscriptionRequest);

                customer = await _gateway.RetrieveCustomer(customer.Id);
                Assert.Equal(cardRequest.CardholderName, customer.Cards.First(c => c.Id == customer.DefaultCardId).CardholderName);

            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        [Fact]
        public async Task SubscribeWithNewCardOnlyOnceWithIdempotencyKeyTest()
        {
            try
            {
                var plan = await _gateway.CreatePlan(_planRequestBuilder.Build());

                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var cardRequest = _cardRequestBuilder.Build();

                var subscriptionRequest = new SubscriptionRequest() { CustomerId = customer.Id, PlanId = plan.Id,TrialEnd=DateTime.Now.AddDays(10), Card = cardRequest };
                var requestOptions = new RequestOptions
                {
                    IdempotencyKey = TestUtils.IdempotencyKey()
                };
                var subscription = await _gateway.CreateSubscription(subscriptionRequest, requestOptions);
                var sameSubscription = await _gateway.CreateSubscription(subscriptionRequest, requestOptions);

                Assert.Equal(subscription.Id, sameSubscription.Id);

            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        [Fact]
        public async Task CancelSubscription()
        {
            try
            {
                // given
                var plan = await _gateway.CreatePlan(_planRequestBuilder.Build());
                var customer = await _gateway.CreateCustomer(_customerRequestBuilder.Build());
                var subscriptionRequest = new SubscriptionRequest() { CustomerId = customer.Id, PlanId = plan.Id, Card = _cardRequestBuilder.Build() };
                var subscription = await _gateway.CreateSubscription(subscriptionRequest);
                // when
                await _gateway.CancelSubscription(new SubscriptionCancelRequest() { SubscriptionId = subscription.Id });
                subscription = await _gateway.RetrieveSubscription(subscription.Id);
                // then
                Assert.True(subscription.Deleted);

            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        [Fact]
        public async Task SubscribeCaptureChargesByDefaultTest()
        {
            try
            {
                var plan = await _gateway.CreatePlan(_planRequestBuilder.Build());

                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var subscriptionRequest = new SubscriptionRequest() { CustomerId = customer.Id, PlanId = plan.Id, TrialEnd = DateTime.Now.AddDays(10) };
                var subscription = await _gateway.CreateSubscription(subscriptionRequest);

                customer = await _gateway.RetrieveCustomer(customer.Id);
                Assert.True(subscription.CaptureCharges);

            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        [Fact]
        public async Task SubscribeWithAddressesTest()
        {
            var address = new AddressBuilder().Build();
            try
            {
                var plan = await _gateway.CreatePlan(_planRequestBuilder.Build());

                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var cardRequest = _cardRequestBuilder.WithCustomerId(customer.Id).Build();

                var subscriptionRequest = new SubscriptionRequest() { CustomerId = customer.Id, PlanId = plan.Id, Card = cardRequest, Billing = new Billing() { Address = address ,Name="name",Vat="123123"} };
                var subscription = await _gateway.CreateSubscription(subscriptionRequest);

                Assert.Equal(subscription.Billing.Address.FirstLine, address.FirstLine);
                Assert.Equal(subscription.Billing.Address.City, address.City);
                Assert.Equal(subscription.Billing.Address.CountryISOCode, address.CountryISOCode);
                Assert.Equal(subscription.Billing.Address.State, address.State);

            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        [Fact]
        public async Task SubscribeWithCardFromChargeTest()
        {
            try
            {
                var plan = await _gateway.CreatePlan(_planRequestBuilder.Build());

                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var chargeRequest = _chargeRequestBuilder.WithCard(_cardRequestBuilder).Build();
                var charge = await _gateway.CreateCharge(chargeRequest);

                var subscriptionRequest = new SubscriptionRequest() { CustomerId = customer.Id, PlanId = plan.Id, Card = new CardRequest() { Id = charge.Id } };
                var subscription = await _gateway.CreateSubscription(subscriptionRequest);

                customer = await _gateway.RetrieveCustomer(customer.Id);
                Assert.Equal(chargeRequest.Card.CardholderName, customer.Cards.First(c => c.Id == customer.DefaultCardId).CardholderName);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }
    
        [Fact]
        public async Task UpdateSubscriptionPeriodEnd()
        {
            try
            {
                var plan = await _gateway.CreatePlan(_planRequestBuilder.Build());

                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var cardRequest = _cardRequestBuilder.Build();
            
                var subscriptionRequest = new SubscriptionRequest() { CustomerId = customer.Id, PlanId = plan.Id , Card = cardRequest };
                var subscription = await _gateway.CreateSubscription(subscriptionRequest);

                
                var updatedEnd = unixDateConverter.ToUnixTimeStamp(DateTime.Now.AddDays(10));
                var subscriptionUpdateRequest = new SubscriptionUpdateRequest() { SubscriptionId = subscription.Id };
                subscriptionUpdateRequest.SetCurrentPeriodEnd(updatedEnd);
                var updatedSubscription = await _gateway.UpdateSubscription(subscriptionUpdateRequest);

                Assert.Equal(unixDateConverter.FromUnixTimeStamp(updatedEnd).ToLocalTime(), updatedSubscription.CurrentPeriodEnd);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        [Fact]
        public async Task UpdateSubscriptionPeriodEndNow()
        {
            try
            {
                var plan = await _gateway.CreatePlan(_planRequestBuilder.Build());

                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var cardRequest = _cardRequestBuilder.Build();
            
                var subscriptionRequest = new SubscriptionRequest() { CustomerId = customer.Id, PlanId = plan.Id , Card = cardRequest };
                var subscription = await _gateway.CreateSubscription(subscriptionRequest);

                var subscriptionUpdateRequest = new SubscriptionUpdateRequest() { SubscriptionId = subscription.Id };
                subscriptionUpdateRequest.SetCurrentPeriodEndNow();
                var updatedSubscription = await _gateway.UpdateSubscription(subscriptionUpdateRequest);

                Assert.True(unixDateConverter.ToUnixTimeStamp(DateTime.Now) -
                    unixDateConverter.ToUnixTimeStamp(updatedSubscription.CurrentPeriodEnd) < 5);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        [Fact]
        public async Task UpdateSubscriptionTrialEnd()
        {
            try
            {
                var plan = await _gateway.CreatePlan(_planRequestBuilder.Build());

                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var cardRequest = _cardRequestBuilder.Build();
            
                var subscriptionRequest = new SubscriptionRequest() { CustomerId = customer.Id, PlanId = plan.Id , TrialEnd = DateTime.Now.AddDays(10), Card = cardRequest };
                var subscription = await _gateway.CreateSubscription(subscriptionRequest);

                var updatedEnd = unixDateConverter.ToUnixTimeStamp(DateTime.Now.AddDays(5));
                var subscriptionUpdateRequest = new SubscriptionUpdateRequest() { SubscriptionId = subscription.Id };
                subscriptionUpdateRequest.SetCurrentPeriodEnd(updatedEnd);
                var updatedSubscription = await _gateway.UpdateSubscription(subscriptionUpdateRequest);

                Assert.Equal(SubscriptionStatus.Trialing, updatedSubscription.Status);
                Assert.Equal(unixDateConverter.FromUnixTimeStamp(updatedEnd).ToLocalTime(), updatedSubscription.CurrentPeriodEnd);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        
        [Fact]
        public async Task UpdateSubscriptionTrialEndNow()
        {
            try
            {
                var plan = await _gateway.CreatePlan(_planRequestBuilder.Build());

                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var cardRequest = _cardRequestBuilder.Build();
            
                var subscriptionRequest = new SubscriptionRequest() { CustomerId = customer.Id, TrialEnd = DateTime.Now.AddDays(10), PlanId = plan.Id , Card = cardRequest };
                var subscription = await _gateway.CreateSubscription(subscriptionRequest);

                var subscriptionUpdateRequest = new SubscriptionUpdateRequest() { SubscriptionId = subscription.Id };
                subscriptionUpdateRequest.SetCurrentPeriodEndNow();
                var updatedSubscription = await _gateway.UpdateSubscription(subscriptionUpdateRequest);

                Assert.Equal(SubscriptionStatus.Active, updatedSubscription.Status);
                Assert.True(unixDateConverter.ToUnixTimeStamp(DateTime.Now) -
                    unixDateConverter.ToUnixTimeStamp(updatedSubscription.CurrentPeriodEnd) < 5);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }
    }
}
