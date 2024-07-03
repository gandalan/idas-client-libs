using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client;

public class BenutzerWebRoutinen : WebRoutinenBase
{
    public BenutzerWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<BenutzerDTO[]> GetBenutzerListeAsync(Guid mandant, bool mitRollenUndRechten = true)
        => await GetAsync<BenutzerDTO[]>($"BenutzerListe?id={mandant}&mitRollenUndRechten={mitRollenUndRechten}");

    public async Task<BenutzerDTO> GetBenutzerAsync(Guid benutzer, bool mitRollenUndRechten = true)
        => await GetAsync<BenutzerDTO>($"Benutzer?id={benutzer}&mitRollenUndRechten={mitRollenUndRechten}");

    public async Task SaveBenutzerAsync(List<BenutzerDTO> list)
        => await Task.Run(() => list.ForEach(async cb => await SaveBenutzerAsync(cb)));

    public async Task SaveBenutzerAsync(BenutzerDTO benutzer)
        => await PutAsync("Benutzer", benutzer);

    public async Task PasswortResetAsync(string benutzerName) =>
        await GetAsync($"PasswortReset?email={Uri.EscapeDataString(benutzerName)}", true);

    public async Task SICSyncWebJob()
    {
        await PostAsync("Benutzer/SICSyncWebJob", null);
    }
}