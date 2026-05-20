using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO.DTOs.Filter;

namespace Gandalan.Client.Contracts.DataServices;

public interface IFilterService
{
    Task<FilterItemDTO[]> GetAllAsync();
    Task<FilterItemDTO> GetFilterItemAsync(Guid id);
    [Obsolete("Use ResolveFilterItemsForContextAsync(Type contextType, List<string> defaultProperties) instead", true)]
    Task<FilterItemDTO[]> GetFilterItemsByContextAsync(string context);
    Task<FilterItemDTO[]> ResolveFilterItemsForContextAsync(Type contextType, List<string> defaultProperties = null, string overrideContextName = null);
    FilterItemDTO GetNewDefaultFilter(Type contextType, List<string> defaultProperties);
    Task SaveAsync(FilterItemDTO dto);
    Task DeleteFilterItemAsync(Guid id);
}
