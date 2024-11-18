using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.Navigation;

public interface INavigationItem
{
    string Group { get; }
    string SubGroup { get; }
    string Caption { get; }
    object Icon { get; }
    int Order { get; }
    bool IsVisible { get; set; }

    Func<Task> Execute { get; }
}
