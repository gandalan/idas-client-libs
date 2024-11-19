using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class LagerbestandWebRoutinen : WebRoutinenBase
{
    public LagerbestandWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<LagerbestandDTO> GetAsync(Guid guid)
        => await GetAsync<LagerbestandDTO>($"Lagerbestand/?id={guid}");

    public async Task<List<LagerbestandDTO>> GetAllAsync(DateTime? changedSince)
    {
        if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
        {
            return await GetAsync<List<LagerbestandDTO>>($"Lagerbestand?changedSince={changedSince.Value:o}");
        }

        return await GetAsync<List<LagerbestandDTO>>("Lagerbestand");
    }

    public async Task<List<LagerbestandDTO>> GetUnterschreitungEisernerBestandAsync()
        => await GetAsync<List<LagerbestandDTO>>("Lagerbestand/UnterschreitungEisernerBestand");

    public async Task<LagerbestandDTO> LagerbuchungAsync(LagerbuchungDTO buchung)
        => await PutAsync<LagerbestandDTO>("Lagerbuchung", buchung);

    public async Task SaveAsync(LagerbestandDTO dto)
        => await PutAsync("Lagerbestand/", dto);

    public async Task DeleteAsync(Guid guid)
        => await DeleteAsync($"Lagerbestand/?id={guid}");

    public async Task<List<LagerbuchungDTO>> GetLagerhistorieAsync(DateTime vonDatum, DateTime bisDatum, bool mitLagerbuchungen = true, bool mitReservierungen = true, Guid? katalogArtikelGuid = null)
        => await GetAsync<List<LagerbuchungDTO>>($"Lagerbuchung/?vonDatum={vonDatum.ToUniversalTime():o}&bisDatum={bisDatum.ToUniversalTime():o}&mitLagerbuchungen={mitLagerbuchungen}&mitReservierungen={mitReservierungen}&katalogArtikelGuid={katalogArtikelGuid}");

    #region Reservierungen

    public async Task<LagerReservierungDTO> GetReservierungAsync(Guid guid)
        => await GetAsync<LagerReservierungDTO>($"LagerReservierungen/?id={guid}");

    public async Task<List<LagerReservierungDTO>> GetAllReservierungenAsync(string artikelnummer = "", string farbkuerzel = "", string farbcode = "", string bezug = "", DateTime? changedSince = null)
    {
        if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
        {
            return await GetAsync<List<LagerReservierungDTO>>($"LagerReservierungen?artikelnummer={artikelnummer}&farbkuerzel={farbkuerzel}&farbcode={farbcode}&bezug={bezug}&changedSince={changedSince.Value:o}");
        }

        return await GetAsync<List<LagerReservierungDTO>>($"LagerReservierungen?artikelnummer={artikelnummer}&farbkuerzel={farbkuerzel}&farbcode={farbcode}&bezug={bezug}");
    }

    public async Task SaveReservierungenAsync(LagerReservierungDTO[] dtos)
        => await PutAsync("LagerReservierungen/", dtos);

    public async Task DeleteReservierungAsync(Guid[] guids)
        => await DeleteAsync($"LagerReservierungen", guids);

    #endregion

    #region Functions
    public async Task<List<long>> GetProduzentenMandantIDsAsync()
        => await GetAsync<List<long>>($"Lagerbestand/GetProduzentIdListe");
    public async Task<List<long>> InitializeLagerbestand(long mandantID)
        => await GetAsync<List<long>>($"Lagerbestand/InitializeBestandForArtikel?mandantId={mandantID}");
    #endregion
}
