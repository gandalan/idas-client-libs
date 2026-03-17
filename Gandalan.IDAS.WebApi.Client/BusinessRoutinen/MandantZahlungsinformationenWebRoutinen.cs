using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Mandanten;

namespace Gandalan.IDAS.WebApi.Client;

public class MandantZahlungsinformationenWebRoutinen(IWebApiConfig settings) : WebRoutinenBase(settings)
{
    public async Task<List<MandantZahlungsinformationDTO>> LadeMandantZahlungsinformationenAsync()
        => await GetAsync<List<MandantZahlungsinformationDTO>>("Mandanten/Zahlungsinformationen");
    public async Task<MandantZahlungsinformationDTO> MandantZahlungsinformationenAnlegenAsync(MandantZahlungsinformationDTO zahlungsinformationen)
        => await PostAsync<MandantZahlungsinformationDTO>("Mandanten/Zahlungsinformationen", zahlungsinformationen);
    public async Task<MandantZahlungsinformationDTO> SpeichereMandantZahlungsinformationenAsync(MandantZahlungsinformationDTO zahlungsinformationen)
        => await PutAsync<MandantZahlungsinformationDTO>($"Mandanten/Zahlungsinformationen/{zahlungsinformationen.MandantZahlungsinformationGuid}", zahlungsinformationen);
    public async Task LoescheMandantZahlungsinformationenAsync(Guid guid)
        => await DeleteAsync($"Mandanten/Zahlungsinformationen/{guid}");
}
