using Shift4.Enums;
using Shift4.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift4Tests.ModelBuilders
{
    public class PlanRequestBuilder : IBuilder<PlanRequest>
    {
        private Random _random = new Random();

        public PlanRequest Build()
        {
            return new PlanRequest() { Amount = 1000, Currency = "EUR", Interval = Interval.Month, Name = "Test plan" + _random.Next(999) };
        }
    }
}
