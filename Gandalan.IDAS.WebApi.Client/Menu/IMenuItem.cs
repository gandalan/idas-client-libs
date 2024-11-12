using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.Menu;

public interface IMenuItem
{
    string Group { get; }
    string Caption { get; }
    object Icon { get; }
    int Order { get; }
    Func<Task> Execute { get; }
    bool CanHandle();
}
