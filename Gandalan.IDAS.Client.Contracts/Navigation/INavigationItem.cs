using System;
using System.Threading.Tasks;

namespace Gandalan.Plugins.Common.Contracts
{
    public interface INavigationItem
    {
        string Group { get; }
        string Caption { get; }
        object Icon { get; }
        int Order { get; }

        Func<Task> Execute { get; } 
    }
}