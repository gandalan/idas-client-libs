using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Data.DTOs.Update;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class ChangeWebRoutinen : WebRoutinenBase
{
    public ChangeWebRoutinen(IWebApiConfig settings) : base(settings)
    {
        }

    public async Task<ChangeDTO[]> GetChangesAsync(string typeName, DateTime changedSince)
        => await GetAsync<ChangeDTO[]>($"Change/?typeName={typeName}&changedSince={changedSince:o}");

    public async Task DeleteOldChanges()
        => await DeleteAsync("Change");
}