using System;

namespace Shift4.Request
{
    public class RequestOptions
    {
        private readonly String _idempotencyKey;

        private RequestOptions(String idempotencyKey) => _idempotencyKey = idempotencyKey;

        public static RequestOptions WithIdempotencyKey(String idempotencyKey)
        {
            return new RequestOptions(idempotencyKey);
        }

        public String GetIdempotencyKey() {
            return _idempotencyKey;
        }

        public bool HasIdempotencyKey() {
            return !String.IsNullOrEmpty(_idempotencyKey);
        }
    }
}