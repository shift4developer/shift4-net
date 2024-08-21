using Xunit;
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
        public class CreditsTests : IntegrationTest
    {
        private CustomerRequestBuilder _customerRequestBuilder = new CustomerRequestBuilder();
        private CardRequestBuilder _cardRequestBuilder = new CardRequestBuilder();
        private TokenRequestBuilder _tokenRequestBuilder = new TokenRequestBuilder();

        /// <summary>
        /// test for creating and listing credits
        /// </summary>
        [Fact]
        public async Task CreateCreditWithTokenAndListCreditsTest()
        {
            try
            {
                var createTokenRequest = _tokenRequestBuilder.Build();
                var token = await _gateway.CreateToken(createTokenRequest);

                var creditRequest = new CreditRequest()
                {
                    Amount = 100,
                    Currency = "EUR",
                    Description = "desc",
                    Card = _cardRequestBuilder.WithId(token.Id).Build()
                };
                var newCredit = await _gateway.CreateCredit(creditRequest);
                var credits = await _gateway.ListCredits();
                Assert.NotNull(credits.List.FirstOrDefault(c => c.Id == newCredit.Id));
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        /// <summary>
        /// test for creating credit only once
        /// </summary>
        [Fact]
        public async Task CreateCreditWithTokenOnlyOnceTest()
        {
            try
            {
                var createTokenRequest = _tokenRequestBuilder.Build();
                var token = await _gateway.CreateToken(createTokenRequest);

                var creditRequest = new CreditRequest()
                {
                    Amount = 100,
                    Currency = "EUR",
                    Description = "desc",
                    Card = _cardRequestBuilder.WithId(token.Id).Build()
                };

                var requestOptions = new RequestOptions().WithIdempotencyKey(TestUtils.IdempotencyKey());
                var newCredit = await _gateway.CreateCredit(creditRequest, requestOptions);
                var sameCredit = await _gateway.CreateCredit(creditRequest, requestOptions);

                Assert.Equal(newCredit.Id, sameCredit.Id);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        /// <summary>
        /// test for creating and retrieving credits
        /// </summary>
        [Fact]
        public async Task CreateCreditWithTokenAndRetrieveCreditTest()
        {
            try {
                var createTokenRequest = _tokenRequestBuilder.Build();
                var token = await _gateway.CreateToken(createTokenRequest);

                var creditRequest = new CreditRequest()
                {
                    Amount = 100,
                    Currency = "EUR",
                    Description = "desc",
                    Card = _cardRequestBuilder.WithId(token.Id).Build()
                };
                var newCredit = await _gateway.CreateCredit(creditRequest);
                var retrievedCredit = await _gateway.RetrieveCredit(newCredit.Id);
                Assert.Equal(creditRequest.Amount, retrievedCredit.Amount);
                Assert.Equal(creditRequest.Currency, retrievedCredit.Currency);
                Assert.Equal(creditRequest.Description, retrievedCredit.Description);
                Assert.Equal(createTokenRequest.CardholderName, retrievedCredit.Card.CardholderName);
                Assert.Equal(createTokenRequest.ExpMonth, retrievedCredit.Card.ExpMonth);
                Assert.Equal(createTokenRequest.ExpYear, retrievedCredit.Card.ExpYear);
                Assert.Equal(createTokenRequest.GetLast4(), retrievedCredit.Card.Last4);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        /// <summary>
        /// test for creating credit with cardId and customerId
        /// </summary>
        [Fact]
        public async Task CreateWithCardIdAndCustomerIdTest()
        {
            try
            {
                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var cardRequest = _cardRequestBuilder.WithCustomerId(customer.Id).Build();
                var card = await _gateway.CreateCard(cardRequest);

                var creditRequest = new CreditRequest()
                {
                    Amount = 100,
                    Currency = "EUR",
                    Description = "desc",
                    Card = _cardRequestBuilder.WithId(card.Id).Build(),
                    CustomerId = customer.Id
                };
                var newCredit = await _gateway.CreateCredit(creditRequest);
                var retrievedCredit = await _gateway.RetrieveCredit(newCredit.Id);
                Assert.Equal(creditRequest.CustomerId, retrievedCredit.CustomerId);

                Assert.Equal(card.Id, retrievedCredit.Card.Id);
                Assert.Equal(cardRequest.CardholderName, retrievedCredit.Card.CardholderName);
                Assert.Equal(cardRequest.ExpMonth, retrievedCredit.Card.ExpMonth);
                Assert.Equal(cardRequest.ExpYear, retrievedCredit.Card.ExpYear);
                Assert.Equal("4242", retrievedCredit.Card.Last4);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        /// <summary>
        /// test for creating credit with card details
        /// </summary>
        [Fact]
        public async Task CreateWithCardDetailsTest()
        {
            try
            {
                var customerRequest = _customerRequestBuilder.Build();
                var customer = await _gateway.CreateCustomer(customerRequest);

                var cardRequest = _cardRequestBuilder.Build();

                var creditRequest = new CreditRequest()
                {
                    Amount = 100,
                    Currency = "EUR",
                    Description = "desc",
                    Card = cardRequest,
                    CustomerId = customer.Id
                };
                var newCredit = await _gateway.CreateCredit(creditRequest);
                var retrievedCredit = await _gateway.RetrieveCredit(newCredit.Id);
                Assert.Equal(creditRequest.CustomerId, retrievedCredit.CustomerId);
                Assert.Equal(cardRequest.CardholderName, retrievedCredit.Card.CardholderName);
                Assert.Equal(cardRequest.ExpMonth, retrievedCredit.Card.ExpMonth);
                Assert.Equal(cardRequest.ExpYear, retrievedCredit.Card.ExpYear);
                Assert.Equal("4242", retrievedCredit.Card.Last4);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        /// <summary>
        /// test for updatingCredits
        /// </summary>
        [Fact]
        public async Task UpdateCreditTest()
        {
            try
            {
                var createTokenRequest = _tokenRequestBuilder.Build();
                var token = await _gateway.CreateToken(createTokenRequest);

                var creditRequest = new CreditRequest()
                {
                    Amount = 100,
                    Currency = "EUR",
                    Description = "desc",
                    Card = _cardRequestBuilder.WithId(token.Id).Build()
                };
                var newCredit = await _gateway.CreateCredit(creditRequest);

                var creditUpdateRequest = new CreditUpdateRequest()
                {
                    CreditId = newCredit.Id,
                    Description = "new description"
                };
                var updatedCredit = await _gateway.UpdateCredit(creditUpdateRequest);
                Assert.Equal(creditUpdateRequest.Description, updatedCredit.Description);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        /// <summary>
        /// test for updatingCredits with idempotency key
        /// </summary>
        [Fact]
        public async Task UpdateCreditOnlyOnceTest()
        {
            try
            {
                var createTokenRequest = _tokenRequestBuilder.Build();
                var token = await _gateway.CreateToken(createTokenRequest);

                var creditRequest = new CreditRequest()
                {
                    Amount = 100,
                    Currency = "EUR",
                    Description = "desc",
                    Card = _cardRequestBuilder.WithId(token.Id).Build()
                };
                var newCredit = await _gateway.CreateCredit(creditRequest);

                var creditUpdateRequest = new CreditUpdateRequest()
                {
                    CreditId = newCredit.Id,
                    Description = "new description"
                };

                var requestOptions = new RequestOptions().WithIdempotencyKey(TestUtils.IdempotencyKey());
                
                var updatedCredit = await _gateway.UpdateCredit(creditUpdateRequest, requestOptions);
                var sameUpdate = await _gateway.UpdateCredit(creditUpdateRequest, requestOptions);

                Assert.Equal(creditUpdateRequest.Description, updatedCredit.Description);
                Assert.Equal(updatedCredit.Id, sameUpdate.Id);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }
    }
}
