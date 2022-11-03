using Shift4.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Exception
{
    public class Shift4Exception : System.Exception
    {
        public Shift4Exception(Error error, string requestType, string requestAction)
        {
            Error = error;
            RequestType = requestType;
            RequestAction = requestAction;
        }

        public Error Error{ get; private set; }
        public string RequestType { get; private set; }
        public string RequestAction { get; private set; }
    }
}
