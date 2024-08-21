using System;

namespace Shift4.Request
{
    public class RequestOptions
    {
        public String IdempotencyKey { get;  set; }

        public RequestOptions()
        {

        }

        public RequestOptions WithIdempotencyKey(String idempotencyKey)
        {
            IdempotencyKey = idempotencyKey;
            return this;
        }
    }
}
