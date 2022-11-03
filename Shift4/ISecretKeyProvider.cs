using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4
{
    public interface ISecretKeyProvider
    {
        string GetSecretKey();
    }
}
