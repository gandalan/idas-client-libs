using System.Collections.Generic;

namespace Gandalan.Client.Contracts.Navigation
{
    public interface INavigationGroup
    {
        string Caption { get; set; }
        IList<INavigationItem> Items { get; set; }
        int Order { get; set; }
    }
}
