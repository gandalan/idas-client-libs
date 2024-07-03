using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client;

public class MandantenAdminWebRoutinen : WebRoutinenBase
{
    public MandantenAdminWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<List<MandantDTO>> LadeMandantenMitFilterAsync(string filter, bool onlyHaendler, bool onlyProduzenten)
    {
        if (!string.IsNullOrEmpty(filter))
        {
            filter = Uri.EscapeDataString(filter);
        }
        else
        {
            filter = string.Empty;
        }

        return await GetAsync<List<MandantDTO>>($"MandantenAdmin?filter={filter}&onlyHaendler={onlyHaendler}&onlyProduzenten={onlyProduzenten}");
    }

    public async Task<MandantDTO> LadeMandantAsync(Guid guid)
        => await GetAsync<MandantDTO>($"MandantenAdmin?guid={guid}");

    public async Task MandantenUmziehenAsync(Guid mandant, Guid zielMandant)
        => await PutAsync("MandantenAdmin", new List<Guid> { mandant, zielMandant });

    public async Task AddAdminRechteAsync(string email)
        => await PostAsync($"MandantenAdmin/SetAdminRechte?email={Uri.EscapeDataString(email)}", null);
}