using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class SammelrechnungenWebRoutinen : WebRoutinenBase
{
    public SammelrechnungenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<SammelrechnungListItemDTO> ErstelleSammelrechnungenAsync(CreateSammelrechnungDTO dto)
        => await PostAsync<SammelrechnungListItemDTO>("Sammelrechnungen/ErstelleSammelrechnungen", dto);

    public async Task<List<SammelrechnungListItemDTO>> GetNotPrintedSammelrechnungenAsync(DateTime? printedSince = null)
        => await GetAsync<List<SammelrechnungListItemDTO>>($"Sammelrechnungen/GetNotPrintedSammelrechnungen?printedSince={printedSince?.ToString("o")}");

    public async Task<List<SammelrechnungListItemDTO>> GetNotExportedSammelrechnungenAsync(DateTime? exportedSince = null)
        => await GetAsync<List<SammelrechnungListItemDTO>>($"Sammelrechnungen/GetNotExportedSammelrechnungen?exportedSince={exportedSince?.ToString("o")}");

    public async Task<SammelrechnungDTO> GetSammelrechnungAsync(Guid guid, bool includeBelegDruckDTO)
        => await GetAsync<SammelrechnungDTO>($"Sammelrechnungen/GetSammelrechnung?guid={guid}&includeBelegDruckDTO={includeBelegDruckDTO}");

    public async Task<List<BelegeInfoDTO>> GetPossibleSammelrechnungRechnungenAsync()
        => await GetAsync<List<BelegeInfoDTO>>("Sammelrechnungen/GetPossibleSammelrechnungRechnungen");

    public async Task<SammelrechnungDTO> UpdateSammelrechnungAsync(SammelrechnungDTO dto)
        => await PostAsync<SammelrechnungDTO>("Sammelrechnungen/UpdateSammelrechnung", dto);

    public async Task<SammelrechnungListItemDTO> AddRechnungToSammelrechnungenAsync(Guid belegGuid, Guid sammelrechnungGuid)
        => await PostAsync<SammelrechnungListItemDTO>("Sammelrechnungen/AddRechnungToSammelrechnungen",
            new AddRechnungSammelrechnungDTO { BelegGuid = belegGuid, SammelrechnungGuid = sammelrechnungGuid });

    public async Task SetRechnungenAlsGedrucktAsync(List<Guid> guidListe, bool setEinzel = false)
        => await PostAsync($"Sammelrechnungen/SetSammelrechnungPrinted?setEinzel={setEinzel}", guidListe);

    public async Task SetRechnungenAlsFibuUebergebenAsync(List<Guid> guidListe, bool setEinzel = false)
        => await PostAsync($"Sammelrechnungen/SetSammelrechnungExported?setEinzel={setEinzel}", guidListe);

    public async Task<List<SammelrechnungListItemDTO>> SearchSammelrechnungAsync(string term)
        => await GetAsync<List<SammelrechnungListItemDTO>>($"Sammelrechnungen/SearchSammelrechnung?term={term}");
}