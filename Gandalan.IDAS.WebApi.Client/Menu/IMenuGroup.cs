using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.Menu
{
    public interface IMenuGroup
    {
        string Caption { get; set; }
        IList<IMenuItem> Items { get; set; }
        int Order { get; set; }
    }
}
