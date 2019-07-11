using System.Collections.Generic;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface ISearchResultDisplay
    {
        void DisplaySearchResult(IList<ISearchResult> searchResults);
    }
}
