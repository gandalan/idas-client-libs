using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts
{
    public interface ISearchProvider
    {
        string Prefix { get; }

        IEnumerable<ISearchResult> Search(string term);
    }

    public interface ISearchResult
    {
        string Title { get; }
        string Description { get; }
        DateTime ItemVersion { get; }
        Func<Task> OpenItem { get; }
    }
}
