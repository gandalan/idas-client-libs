using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO.DTOs.Filter;

namespace Gandalan.Client.Contracts.DataServices;

public interface IFilterService
{
    Task<FilterItemDTO[]> GetAllAsync();
    Task<FilterItemDTO> GetFilterItemAsync(Guid id);
    Task<FilterItemDTO[]> GetFilterItemsByContextAsync(string context);
    Task SaveAsync(FilterItemDTO dto);
    Task DeleteAsync(Guid id);
}