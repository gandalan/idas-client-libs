using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client;

public class VorgangBlackListWebRoutinen : WebRoutinenBase
{
    public VorgangBlackListWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<List<VorgangBlackListEntryDTO>> GetAllBlackListEntryAsync()
        => await GetAsync<List<VorgangBlackListEntryDTO>>($"VorgangBlackList/GetAllBlackListEntry");

    public async Task AddBlackListEntryAsync(Guid vorgangGuid, Guid appGuid, bool onlyUser)
        => await PostAsync($"VorgangBlackList/AddBlackListEntry?vorgangGuid={vorgangGuid}&appGuid={appGuid}&onlyUser={onlyUser}", null);

    public async Task RemoveBlackListEntryAsync(Guid vorgangBlackListGuid)
        => await DeleteAsync($"VorgangBlackList/RemoveBlackListEntry?vorgangBlackListGuid={vorgangBlackListGuid}");
}
