using System;
using System.Linq;

namespace Shift4Tests.Utils
{
    public static class TestUtils
    {
        private static readonly Random random = new Random();
        
        public static string IdempotencyKey()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}