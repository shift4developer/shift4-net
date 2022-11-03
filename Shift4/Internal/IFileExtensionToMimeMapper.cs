using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Internal
{
    public interface IFileExtensionToMimeMapper
    {
        string GetMimeType(string fileName);
    }
}
