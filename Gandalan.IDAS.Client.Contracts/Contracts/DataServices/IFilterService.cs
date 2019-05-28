using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;
using Gandalan.IDAS.WebApi.DTO.DTOs.Filter;

namespace Gandalan.Client.Common.Contracts.DataServices
{
    public interface IFilterService
    {
        Task<FilterItemDTO[]> GetAllAsync();
        Task<FilterItemDTO> GetFilterItemAsync(Guid id);
        Task<FilterItemDTO[]> GetFilterItemsByContextAsync(string context);
        Task SaveAsync(string context, string serializedFilterSetting);
        Task DeleteAsync(Guid id);
    }
}
