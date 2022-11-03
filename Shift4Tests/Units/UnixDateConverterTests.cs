using Xunit;
using Shift4.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift4Tests.Units
{
        public class UnixDateConverterTests : BaseUnitTestsSet
    {
        UnixDateConverter _subject = new UnixDateConverter();

        [Fact]
        public void ToUnixTimeStampTest()
        {
            var result = _subject.ToUnixTimeStamp(new DateTime(2017, 10, 01, 12, 33, 37, DateTimeKind.Utc));
            Assert.Equal(1506861217, result);
        }

        [Fact]
        public void FromUnixTimeStampTest()
        {
            var result = _subject.FromUnixTimeStamp(1506861217);
            Assert.Equal(new DateTime(2017,10,01,12,33,37,DateTimeKind.Utc), result);
        }

    }
}
