using Shift4.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift4Tests.ModelBuilders
{
    public class CardRequestBuilder : IBuilder<CardRequest>
    {
        private string _customerId=null;
        private string _id=null;
        private string _cardNumber = "4242424242424242";
        private string _cardholderName = "test cardholder";

        public CardRequestBuilder WithCustomerId(string id)
        {
            _customerId = id;
            return this;
        }

        public CardRequestBuilder WithNumberCausingDispute()
        {
            _cardNumber = "4242000000000018";
            return this;
        }

        public CardRequestBuilder WithNumberCausingFraudWarning()
        {
            _cardNumber = "4242000000000208";
            return this;
        }

        public CardRequestBuilder WithWrongNumber()
        {
            _cardNumber = "44444444";
            return this;
        }

        public CardRequestBuilder WithAniCheckCard()
        {
            _cardNumber = "4242000000000513";
            _cardholderName = "Ani check";
            return this;
        }

        public CardRequestBuilder WithAvsCheckCard()
        {
            _cardNumber = "4242000000000315";
            return this;
        }

        public CardRequestBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public CardRequest Build()
        {
            if (string.IsNullOrEmpty(_id))
            {
                return new CardRequest() { CustomerId = _customerId, Number = _cardNumber, ExpMonth = "12", ExpYear = GetCorrectCardExpiryYear(), Cvc = "123", CardholderName = _cardholderName };
            }
            else
            {
                return new CardRequest() { Id = _id };
            }
        }

        private string GetCorrectCardExpiryYear()
        {
            return (DateTime.Today.Year + 1).ToString();
        }
    }
}
