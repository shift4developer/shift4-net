using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shift4.Response;

namespace Shift4.Converters
{
    public abstract class BaseObjectTypeConverter : JsonConverter
    {
        protected (string, BaseResponse) convertObjectType(JsonReader reader, JsonSerializer serializer) {
            JObject jObject = JObject.Load(reader);
            switch (jObject.GetValue("objectType").ToString())
            {
                case "charge":
                    var charge = new Charge();
                    serializer.Populate(jObject.CreateReader(), charge);
                    return (charge.Id, charge);
                case "credit":
                    var credit = new Credit();
                    serializer.Populate(jObject.CreateReader(), credit);
                    return (credit.Id, credit);
                case "dispute":
                    var dispute = new Dispute();
                    serializer.Populate(jObject.CreateReader(), dispute);
                    return (dispute.Id, dispute);
                case "refund":
                    var refund = new Refund();
                    serializer.Populate(jObject.CreateReader(), refund);
                    return (refund.Id, refund);
                case "subscription":
                    var subscription = new Subscription();
                    serializer.Populate(jObject.CreateReader(), subscription);
                    return (subscription.Id, subscription);
                case "plan":
                    var plan = new Plan();
                    serializer.Populate(jObject.CreateReader(), plan);
                    return (plan.Id, plan);
                case "customer":
                    var customer = new Customer();
                    serializer.Populate(jObject.CreateReader(), customer);
                    return (customer.Id, customer);
                case "fraud_warning":
                    var warning = new FraudWarning();
                    serializer.Populate(jObject.CreateReader(), warning);
                    return (warning.Id, warning);
                case "card":
                    var card = new Card();
                    serializer.Populate(jObject.CreateReader(), card);
                    return (card.Id, card);
                case "payout":
                    var payout = new Payout();
                    serializer.Populate(jObject.CreateReader(), payout);
                    return (payout.Id, payout);
            }
            return (null, null);
        }
    }
}