using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Data;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class AVWebRoutinen : WebRoutinenBase
{
    public AVWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<BelegPositionAVDTO[]> GetAllBelegPositionenAVAsync()
    {
        return await GetAsync<BelegPositionAVDTO[]>("BelegPositionenAV");
    }

    public async Task<BelegPositionAVDTO[]> GetAllBelegPositionenAVAsync(DateTime changedSince)
    {
        return await GetAsync<BelegPositionAVDTO[]>($"BelegPositionenAV/?changedSince={changedSince:o}");
    }

    public async Task<BelegPositionAVDTO[]> GetSerieBelegPositionenAVAsync(Guid serieGuid, bool includeOriginalBeleg = true, bool includeProdDaten = true)
    {
        return await GetAsync<BelegPositionAVDTO[]>($"BelegPositionenAV/?serieGuid={serieGuid}&includeOriginalBeleg={includeOriginalBeleg}&includeProdDaten={includeProdDaten}");
    }

    public async Task<BelegPositionAVDTO[]> GetVorgangBelegPositionenAVAsync(Guid vorgangGuid, bool includeOriginalBeleg = true, bool includeProdDaten = true)
    {
        return await GetAsync<BelegPositionAVDTO[]>($"BelegPositionenAV/?vorgangGuid={vorgangGuid}&includeOriginalBeleg={includeOriginalBeleg}&includeProdDaten={includeProdDaten}");
    }

    public async Task<BelegPositionAVDTO[]> GetVorgaengeBelegPositionenAVAsync(List<Guid> vorgangGuids, bool includeOriginalBeleg = true, bool includeProdDaten = true)
    {
        var vorgangGuidsString = string.Join("&vorgangGuids=", vorgangGuids);
        return await GetAsync<BelegPositionAVDTO[]>($"BelegPositionenAVByVorgangIds/?vorgangGuids={vorgangGuidsString}&includeOriginalBeleg={includeOriginalBeleg}&includeProdDaten={includeProdDaten}");
    }

    public async Task<List<BelegPositionAVDTO>> GetBelegPositionenAVAsync(Guid belegpositionGuid)
    {
        return await GetAsync<List<BelegPositionAVDTO>>($"BelegPositionenAV/{belegpositionGuid}");
    }

    public async Task SaveBelegPositionenAVAsync(BelegPositionAVDTO position)
    {
        await PutAsync("BelegPositionenAV", position);
    }

    public async Task<List<BelegPositionAVDTO>> SaveBelegPositionenAVAsync(List<BelegPositionAVDTO> positionen)
    {
        return await PutAsync<List<BelegPositionAVDTO>>("BelegPositionenAVBulk", positionen);
    }

    public async Task<List<BelegPositionAVDTO>> SaveBelegPositionenAVToSerieAsync(Guid serieGuid, List<Guid> positionen)
    {
        return await PutAsync<List<BelegPositionAVDTO>>($"BelegPositionenAVBulk/AddToSerie/{serieGuid}", positionen);
    }

    public async Task BelegPositionenAVBerechnenAsync(List<Guid> guids)
    {
        await PutAsync("BelegPositionenAVBulk/AVBerechnung", guids);
    }

    public async Task<BelegPositionAVDTO[]> GetAllBelegPositionenAVAsync(bool includeOriginalBeleg = true, bool includeProdDaten = true)
    {
        return await GetAsync<BelegPositionAVDTO[]>($"BelegPositionenAV?includeOriginalBeleg={includeOriginalBeleg}&includeProdDaten={includeProdDaten}");
    }

    public async Task<BelegPositionAVDTO[]> GetAllBelegPositionenAVAsync(DateTime changedSince, bool includeOriginalBeleg = true, bool includeProdDaten = true)
    {
        return await GetAsync<BelegPositionAVDTO[]>($"BelegPositionenAV/?changedSince={changedSince:o}&includeOriginalBeleg={includeOriginalBeleg}&includeProdDaten={includeProdDaten}");
    }

    public async Task<BelegPositionAVDTO> GetBelegPositionAVByIdAsync(Guid avGuid)
    {
        return await GetAsync<BelegPositionAVDTO>($"BelegPositionenAVById/{avGuid}");
    }

    public async Task<IList<BelegPositionAVDTO>> GetBelegPositionAVByPCodeAsync(string pcode, bool includeOriginalBeleg = true, bool includeProdDaten = true)
    {
        return await GetAsync<IList<BelegPositionAVDTO>>($"BelegPositionenAVByPCode/{pcode}?includeOriginalBeleg={includeOriginalBeleg}&includeProdDaten={includeProdDaten}");
    }

    public async Task<IList<BelegPositionAVDTO>> SearchBelegPositionAVByPCodeAsync(string search)
    {
        return await GetAsync<IList<BelegPositionAVDTO>>($"BelegPositionenAVSearchByPCode?search={Uri.EscapeDataString(search)}");
    }

    public async Task DeleteBelegPositionenAVAsync(Guid guid)
    {
        await DeleteAsync($"BelegPositionenAV/{guid}");
    }

    public async Task DeleteBelegPositionenAVAsync(List<Guid> guids)
    {
        await DeleteAsync("BelegPositionenAVBulk", guids);
    }

    public async Task BelegPositionenSerienZuordnen(Guid belegGuid, List<PositionSerieItemDTO> positionSerieItems)
    {
        await PutAsync($"BelegPositionenAVBulk/SerienZuorden/{belegGuid}", positionSerieItems);
    }
}