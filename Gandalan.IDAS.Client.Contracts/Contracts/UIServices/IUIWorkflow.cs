using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IUIWorkflow<T>
    {
        void Handle(T data);
    }
}
