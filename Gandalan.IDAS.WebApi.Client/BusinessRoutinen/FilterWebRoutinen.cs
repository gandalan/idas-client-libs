using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO.DTOs.Filter;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class FilterWebRoutinen : WebRoutinenBase
{
    public FilterWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<FilterItemDTO[]> GetAllAsync()
        => await GetAsync<FilterItemDTO[]>("Filter");

    public async Task<FilterItemDTO> GetFilterItemAsync(Guid id)
        => await GetAsync<FilterItemDTO>($"Filter?id={id}");

    public async Task<FilterItemDTO[]> GetFilterItemsByContextAsync(string context)
        => await GetAsync<FilterItemDTO[]>($"Filter?context={context}");

    public async Task SaveAsync(FilterItemDTO dto)
        => await PutAsync("Filter", dto);
}