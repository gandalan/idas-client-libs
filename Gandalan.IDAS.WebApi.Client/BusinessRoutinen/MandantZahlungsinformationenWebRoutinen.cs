using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Mandanten;

namespace Gandalan.IDAS.WebApi.Client;

public class MandantZahlungsinformationenWebRoutinen(IWebApiConfig settings) : WebRoutinenBase(settings)
{
    public async Task<List<MandantZahlungsinformationDTO>> LadeMandantZahlungsinformationenAsync()
        => await GetAsync<List<MandantZahlungsinformationDTO>>("MandantZahlungsinformationen");
    public async Task<MandantZahlungsinformationDTO> UpsertMandantZahlungsinformationenAsync(MandantZahlungsinformationDTO zahlungsinformationen)
        => await PostAsync<MandantZahlungsinformationDTO>("MandantZahlungsinformationen", zahlungsinformationen);

    public async Task LoescheMandantZahlungsinformationenAsync(Guid guid)
        => await DeleteAsync($"MandantZahlungsinformationen/{guid}");
}
