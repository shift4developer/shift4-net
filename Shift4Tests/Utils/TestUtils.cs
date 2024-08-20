using System;
using System.Linq;

namespace Shift4Tests.Utils
{
    public static class TestUtils
    {
        public static string IdempotencyKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}