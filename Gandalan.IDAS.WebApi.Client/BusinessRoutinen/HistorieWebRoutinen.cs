using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class HistorieWebRoutinen : WebRoutinenBase
{
    public HistorieWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<VorgangHistorienDTO> GetVorgangHistorieAsync(Guid vorgangGuid, bool includeBelege = false, bool includePositionen = false)
        => await GetAsync<VorgangHistorienDTO>($"HistorieVorgang?vorgangGuid={vorgangGuid}&includeBelege={includeBelege}&includePositionen={includePositionen}");

    public async Task<BelegHistorienDTO> GetBelegHistorieAsync(Guid belegGuid, bool includePositionen = false)
        => await GetAsync<BelegHistorienDTO>($"HistorieBeleg?belegGuid={belegGuid}&includePositionen={includePositionen}");

    public async Task<BelegPositionHistorienDTO> GetBelegPositionHistorieAsync(Guid positionGuid)
        => await GetAsync<BelegPositionHistorienDTO>($"HistorieBelegPosition?positionGuid={positionGuid}");

    public async Task AddVorgangHistorieAsync(Guid vorgangGuid, VorgangHistorieDTO historyDto)
        => await PostAsync($"HistorieVorgang?vorgangGuid={vorgangGuid}", historyDto);

    public async Task AddBelegHistorieAsync(Guid belegGuid, BelegHistorieDTO historyDto)
        => await PostAsync($"HistorieBeleg?belegGuid={belegGuid}", historyDto);

    public async Task AddBelegPositionHistorieAsync(Guid positionGuid, BelegPositionHistorieDTO historyDto)
        => await PostAsync($"HistorieBelegPosition?positionGuid={positionGuid}", historyDto);

    public async Task AddVorgangHistorieFromFunctionAsync(Guid vorgangGuid, VorgangHistorieDTO historyDto, long mandantID)
        => await PostAsync($"AddVorgangHistorieFromFunction?vorgangGuid={vorgangGuid}&mandantID={mandantID}", historyDto);

    public async Task AddBelegPositionHistorieFromFunctionAsync(Guid positionGuid, BelegPositionHistorieDTO historyDto, long mandantID)
        => await PostAsync($"AddBelegPositionHistorieFromFunction?positionGuid={positionGuid}&mandantID={mandantID}", historyDto);

    public async Task<string> GetLetzterBearbeiter(Guid belegGuid)
        => await GetAsync<string>($"HistorieBeleg/LetzterBearbeiter?belegGuid={belegGuid}");

    public async Task<Dictionary<Guid, string>> GetLetzteBearbeiter(IEnumerable<Guid> belegGuids)
        => await PostAsync<Dictionary<Guid, string>>($"HistorieBeleg/LetzteBearbeiter", belegGuids);
}
