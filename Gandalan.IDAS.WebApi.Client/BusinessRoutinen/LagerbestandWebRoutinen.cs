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

    // vonDatum and bisDatum need to be converted to string and back otherwise the backend will receive null values
    public async Task<List<LagerbuchungDTO>> GetLagerhistorieAsync(DateTime vonDatum, DateTime bisDatum, bool mitLagerbuchungen = true, bool mitReservierungen = true, string katalogNummer = "")
        => await GetAsync<List<LagerbuchungDTO>>($"Lagerbuchung/?vonDatum={DateTime.Parse(vonDatum.ToString()):o}&bisDatum={DateTime.Parse(bisDatum.ToString()):o}&mitLagerbuchungen={mitLagerbuchungen}&mitReservierungen={mitReservierungen}&katalogNummer={katalogNummer}");

    #region Functions
    public async Task<List<long>> GetProduzentenMandantIDsAsync()
        => await GetAsync<List<long>>($"Lagerbestand/GetProduzentIdListe");
    public async Task<List<long>> InitializeLagerbestand(long mandantID)
        => await GetAsync<List<long>>($"Lagerbestand/InitializeBestandForArtikel?mandantId={mandantID}");
    #endregion
}
