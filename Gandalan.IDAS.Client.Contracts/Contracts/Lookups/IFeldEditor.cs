using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.Lookups
{
    public interface IFeldEditor<T,U> : ILookupDialog<T, U>
    {
        bool CanHandle(string tag);
    }
}
