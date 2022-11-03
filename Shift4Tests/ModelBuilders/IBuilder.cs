using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift4Tests.ModelBuilders
{
    public interface IBuilder<T>
    {
        T Build();
    }
}
