﻿using Xunit;
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
        public class CustomerTests : IntegrationTest
    {
        private CustomerRequestBuilder _customerRequestBuilder = new CustomerRequestBuilder();
        private CardRequestBuilder _cardRequestBuilder = new CardRequestBuilder();
        private TokenRequestBuilder _tokenRequestBuilder = new TokenRequestBuilder();

        [Fact]
        public async Task CustomerWithNewCardTest()
        {
            try
            {
                var customerRequest = _customerRequestBuilder.WithCard(_cardRequestBuilder).Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                Assert.Single(customer.Cards);
                Assert.Equal(customerRequest.Card.CardholderName, customer.Cards.First().CardholderName);

            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        [Fact]
        public async Task CreateCustomeOnlyOnceWithIdempotencyKeyTest()
        {
            try
            {
                var requestOptions = new RequestOptions
                {
                    IdempotencyKey = TestUtils.IdempotencyKey()
                };
                var customerRequest = _customerRequestBuilder.WithCard(_cardRequestBuilder).Build();
                var customer = await _gateway.CreateCustomer(customerRequest, requestOptions);
                var sameCustomer = await _gateway.CreateCustomer(customerRequest, requestOptions);

                Assert.Single(customer.Cards);
                Assert.Equal(customerRequest.Card.CardholderName, customer.Cards.First().CardholderName);
                Assert.Equal(customer.Id, sameCustomer.Id);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        [Fact]
        public async Task CustomerWithCardTokenTest()
        {
            try
            {
                var createTokenRequest = _tokenRequestBuilder.Build();
                var token = await _gateway.CreateToken(createTokenRequest);
                token = await _gateway.RetrieveToken(token.Id);

                var customerRequest = _customerRequestBuilder.WithCard(_cardRequestBuilder.WithId(token.Id)).Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                Assert.Single(customer.Cards);
                Assert.Equal(createTokenRequest.CardholderName, customer.Cards.First().CardholderName);

            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        [Fact]
        public async Task ListCustomersWithGivenEmailTest()
        {
            try
            {
                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var customerListRequest = new CustomerListRequest()
                {
                    Email = customerRequest.Email
                };
                var list = await _gateway.ListCustomers(customerListRequest);
                Assert.True(list.List.Count > 0);
                Assert.True(list.List.All(item => item.Email == customerRequest.Email));
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }
    }
}
