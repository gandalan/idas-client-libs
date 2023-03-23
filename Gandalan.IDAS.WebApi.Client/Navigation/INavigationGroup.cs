using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.Navigation
{
    public interface INavigationGroup
    {
        string Caption { get; set; }
        ObservableCollection<INavigationItem> Items { get; set; }
        int Order { get; set; }
    }
}
