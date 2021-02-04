using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts
{
    public interface ISearchProvider
    {
        string Prefix { get; }
        Task<IEnumerable<ISearchResult>> Search(string term);
    }

    public interface ISearchResult
    {
        Guid ItemGuid { get; }
        string Title { get; }
        string Description { get; }
        string Type { get; }
        DateTime ItemVersion { get; }
        Func<Task> OpenItem { get; }
    }
}
