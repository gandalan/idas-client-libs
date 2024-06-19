using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class AblageFachWebRoutinen : WebRoutinenBase
{
    public AblageFachWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<AblageFachDTO> Get(Guid guid)
    {
        return await GetAsync<AblageFachDTO>("AblageFach/?id=" + guid);
    }

    public async Task<List<AblageFachDTO>> GetAll(DateTime? changedSince, bool includeDetails = true)
    {
        if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
        {
            return await GetAsync<List<AblageFachDTO>>($"AblageFach?changedSince={changedSince.Value:o}&includeDetails={includeDetails}");
        }

        return await GetAsync<List<AblageFachDTO>>($"AblageFach?includeDetails={includeDetails}");
    }

    public async Task Save(AblageFachDTO dto)
    {
        await PutAsync("AblageFach/", dto);
    }

    public async Task Delete(Guid guid)
    {
        await DeleteAsync("AblageFach/?id=" + guid);
    }

    public async Task<AblageFachDTO> GetAsync(Guid guid)
    {
        return await GetAsync<AblageFachDTO>("AblageFach/?id=" + guid);
    }

    public async Task<List<AblageFachDTO>> GetAllAsync(DateTime? changedSince, bool includeDetails = true)
    {
        if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
        {
            return await GetAsync<List<AblageFachDTO>>($"AblageFach?changedSince={changedSince.Value:o}&includeDetails={includeDetails}");
        }

        return await GetAsync<List<AblageFachDTO>>($"AblageFach?includeDetails={includeDetails}");
    }

    public async Task SaveAsync(AblageFachDTO dto)
    {
        await PutAsync("AblageFach/", dto);
    }

    public async Task DeleteAsync(Guid guid)
    {
        await DeleteAsync("AblageFach/?id=" + guid);
    }
}
