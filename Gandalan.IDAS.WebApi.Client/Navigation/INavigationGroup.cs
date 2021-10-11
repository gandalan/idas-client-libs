using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.Navigation
{
    public interface INavigationGroup
    {
        string Caption { get; set; }
        IList<INavigationItem> Items { get; set; }
        int Order { get; set; }
    }
}
