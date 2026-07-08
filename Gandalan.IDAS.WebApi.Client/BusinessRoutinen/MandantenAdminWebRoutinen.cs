using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Benutzer;
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

    public async Task<BenutzerDiagnoseDatenDTO> GetDiagnoseDataAsync(string benutzerMailAdresse)
        => await GetAsync<BenutzerDiagnoseDatenDTO>($"MandantenAdmin/GetBenutzerDiagnoseDaten?emailadresse={Uri.EscapeDataString(benutzerMailAdresse)}");

    public async Task ResetPasswortResetCounterAsync(string email)
        => await PostAsync($"MandantenAdmin/ResetPasswortResetCounter?email={Uri.EscapeDataString(email)}", null);

    public async Task ResetBenutzerMandantCacheAsync(string email)
        => await PostAsync($"MandantenAdmin/ResetBenutzerMandantCache?email={Uri.EscapeDataString(email)}", null);

    public async Task<string> SetNeuesPasswortAsync(PasswortAendernDTO dto)
        => await PostAsync<string>($"MandantenAdmin/SetNeuesPasswort", dto);

    public async Task<UserAuthTokenDTO> GetUserAuthTokenAsync(string email)
        => await GetAsync<UserAuthTokenDTO>($"MandantenAdmin/GetUserAuthToken?emailadresse={Uri.EscapeDataString(email)}", null);

    public async Task<string> MandantDeaktivierenAsync(string email)
        => await PostAsync<string>($"MandantenAdmin/MandantDeaktivieren?emailadresse={Uri.EscapeDataString(email)}", null);

    /// <summary>
    /// Benennt die Anmelde-E-Mail eines Händlers um: legt einen neuen Benutzer mit der
    /// neuen Adresse an, hängt alle Vorgänge um und archiviert die bisherigen Benutzer
    /// des Mandanten. Erfordert serverseitig die Berechtigung <c>admin.mandantumzug</c>.
    /// </summary>
    public async Task<HaendlerArchivierenResultDTO> HaendlerArchivierenAsync(string alteMail, string neueMail)
        => await PostAsync<HaendlerArchivierenResultDTO>(
            $"HaendlerArchivieren?alteMail={Uri.EscapeDataString(alteMail)}&neueMail={Uri.EscapeDataString(neueMail)}", null);
}
