using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.Lookups
{
    public interface IFeldEditor
    {
        bool CanHandle(string tag);
    }

    public interface IFeldEditor<T,U> : IFeldEditor, ILookupDialog<T, U>
    {   
    }
}
