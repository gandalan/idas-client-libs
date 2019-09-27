using System.Collections.Generic;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface ISearchResultDisplay
    {
        void ShowSearchResultControl();
        void DisplaySearchResult(string searchText);                    
    }
}
