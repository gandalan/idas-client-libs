using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface ISearchResultDisplay
    {
        Task DisplaySearchResult(string searchText);                    
    }
}
