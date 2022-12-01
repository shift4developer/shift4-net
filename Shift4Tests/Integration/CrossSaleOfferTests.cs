using Xunit;
using Shift4.Enums;
using Shift4.Exception;
using Shift4.Request;
using Shift4.Request.CrossSaleOffer;
using Shift4.Response;
using Shift4Tests.ModelBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift4Tests.Integration
{
        public class CrossSaleOfferTests : IntegrationTest
    {
        private PlanRequestBuilder _planRequestBuilder = new PlanRequestBuilder();

        [Fact]
        public async Task CreateCrossSaleOfferTest()
        {
            try
            {
                var createRequest = GetCreateRequest();
                var offer = await _gateway.CreateCrossSaleOffer(createRequest);
                Assert.Equal(createRequest.CompanyLocation, offer.CompanyLocation);
                Assert.Equal(createRequest.Description, offer.Description);
                Assert.Equal(createRequest.Template, offer.Template);
                Assert.Equal(createRequest.CompanyName, offer.CompanyName);
                Assert.Equal(createRequest.Template, offer.Template);
                Assert.Equal(createRequest.Charge.Amount, offer.Charge.Amount);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }


        [Fact]
        public async Task CreateCrossSaleOfferWithSubscriptionTest()
        {
            try
            {
                var plan = await _gateway.CreatePlan(_planRequestBuilder.Build());
                var createRequest = GetCreateRequest();
                createRequest.Subscription = new CrossSaleOfferRequestSubscription()
                {
                    PlanId = plan.Id
                };
                createRequest.Charge = null;
                var offer = await _gateway.CreateCrossSaleOffer(createRequest);
                Assert.Equal(createRequest.CompanyLocation, offer.CompanyLocation);
                Assert.Equal(createRequest.Description, offer.Description);
                Assert.Equal(createRequest.Template, offer.Template);
                Assert.Equal(createRequest.CompanyName, offer.CompanyName);
                Assert.Equal(createRequest.Template, offer.Template);
                Assert.Equal(createRequest.Subscription.PlanId, offer.Subscription.PlanId);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        [Fact]
        public async Task RetrieveCrossSaleOfferTest()
        {
            try
            {
                var createRequest = GetCreateRequest();
                var offer = await _gateway.CreateCrossSaleOffer(createRequest);
                var retrievedOffer = await _gateway.RetrieveCrossSaleOffer(offer.Id);
                Assert.Equal(createRequest.CompanyLocation, retrievedOffer.CompanyLocation);
                Assert.Equal(createRequest.Description, retrievedOffer.Description);
                Assert.Equal(createRequest.Template, retrievedOffer.Template);
                Assert.Equal(createRequest.CompanyName, retrievedOffer.CompanyName);
                Assert.Equal(createRequest.Template, retrievedOffer.Template);
                Assert.Equal(createRequest.Charge.Amount, retrievedOffer.Charge.Amount);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        [Fact]
        public async Task UpdateCrossSaleOfferTest()
        {
            try
            {
                var createRequest = GetCreateRequest();
                var offer = await _gateway.CreateCrossSaleOffer(createRequest);
                var updateRequest = new CrossSaleOfferUpdateRequest()
                {
                    CrossSaleOfferId = offer.Id,
                    CompanyName = "new name",
                    Template = CrossSaleOfferTemplate.ImageAndText,
                    ImageData = "iVBORw0KGgoAAAANSUhEUgAAAEEAAAAaCAIAAABn3KYmAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAA1SURBVFhH7c8BDQAwEAOh+Tfd2eCTwwFv93UwdDB0MHQwdDB0MHQwdDB0MHQwdDB0MNw/bB/PbLtQntZXkAAAAABJRU5ErkJggg==",
                    Charge = new CrossSaleOfferRequestCharge()
                    {
                        Amount = 20,
                        Capture = false,
                        Currency = "PLN"
                    },
                    Description = "new description",
                    Title = "new title",
                    CompanyLocation = "DE"

                };
                var updatedOffer = await _gateway.UpdateCrossSaleOffer(updateRequest);
                Assert.Equal(updateRequest.CompanyLocation, updatedOffer.CompanyLocation);
                Assert.Equal(updateRequest.Description, updatedOffer.Description);
                Assert.Equal(updateRequest.CompanyName, updatedOffer.CompanyName);
                Assert.Equal(updateRequest.Charge.Amount, updatedOffer.Charge.Amount);
                Assert.Equal(updateRequest.Title, updatedOffer.Title);
                Assert.Equal(updateRequest.Template, updatedOffer.Template);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        [Fact]
        public async Task ListCrossSaleOfferTest()
        {
            try
            {
                var createRequest = GetCreateRequest();
                var offer = await _gateway.CreateCrossSaleOffer(createRequest);
                var retrievedOffers = await _gateway.ListCrossSaleOffers();
                Assert.Contains(retrievedOffers.List, x => x.Id == offer.Id);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }

        }

        [Fact]
        public async Task ListCrossSaleOfferWithFilterTest()
        {
            try
            {
                var createRequest = GetCreateRequest();
                var offer = await _gateway.CreateCrossSaleOffer(createRequest);
                var listRequest = new CrossSaleOfferListRequest()
                {
                    Limit = 100,
                    EndingBeforeId = offer.Id
                };
                var retrievedOffers = await _gateway.ListCrossSaleOffers(listRequest);
                Assert.True(retrievedOffers.List.All(x => x.Id != offer.Id));
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        [Fact]
        public async Task DeleteCrossSaleOfferTest()
        {
            try
            {
                var createRequest = GetCreateRequest();
                var offer = await _gateway.CreateCrossSaleOffer(createRequest);
                var deleteResponse = await _gateway.DeleteCrossSaleOffer(offer.Id);
                Assert.Equal(offer.Id, deleteResponse.Id);
            }
            catch (Shift4Exception exc)
            {
                HandleApiException(exc);
            }
        }

        private CrossSaleOfferRequest GetCreateRequest()
        {

            return new CrossSaleOfferRequest()
            {
                CompanyLocation = "PL",
                CompanyName = "test company",
                Description = "description",
                Title = "offer title",
                TermsAndConditionsUrl = "https://dev.shift4.com/docs/terms",
                Template = Shift4.Enums.CrossSaleOfferTemplate.TextOnly,
                Charge = new CrossSaleOfferRequestCharge()
                {
                    Amount = 100,
                    Capture = true,
                    Currency = "PLN"
                }

            };
        }
    }
}
