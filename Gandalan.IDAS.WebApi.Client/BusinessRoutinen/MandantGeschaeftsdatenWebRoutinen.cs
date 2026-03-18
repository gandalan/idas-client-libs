using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Mandanten;

namespace Gandalan.IDAS.WebApi.Client;

public class MandantGeschaeftsdatenWebRoutinen(IWebApiConfig settings) : WebRoutinenBase(settings)
{
    public async Task<List<MandantGeschaeftsdatenDTO>> LadeMandantGeschaeftsdatenAsync()
    => await GetAsync<List<MandantGeschaeftsdatenDTO>>("MandantenGeschaeftsdaten");

    public async Task<MandantGeschaeftsdatenDTO> MandantGeschaeftsdatenAnlegenAsync(MandantGeschaeftsdatenDTO geschaeftsdaten)
        => await PostAsync<MandantGeschaeftsdatenDTO>("MandantenGeschaeftsdaten", geschaeftsdaten);

    public async Task<MandantGeschaeftsdatenDTO> SpeichereMandantGeschaeftsdatenAsync(MandantGeschaeftsdatenDTO geschaeftsdaten)
        => await PutAsync<MandantGeschaeftsdatenDTO>($"MandantenGeschaeftsdaten/{geschaeftsdaten.MandantGeschaeftsdatenGuid}", geschaeftsdaten);

    public async Task LoescheMandantGeschaeftsdatenAsync(Guid guid)
        => await DeleteAsync($"MandantenGeschaeftsdaten/{guid}");
}
