using System.Collections.Generic;

namespace Gandalan.Client.Contracts.Menu
{
    public interface IMenuGroup
    {
        string Caption { get; set; }
        IList<IMenuItem> Items { get; set; }
        int Order { get; set; }
    }
}
