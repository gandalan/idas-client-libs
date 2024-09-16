using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class AppWebRoutinen : WebRoutinenBase
{
    public AppWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<AppActivationStatusDTO> GetMandantStatusByKundeAsync(Guid kundeGuid)
    {
        return await GetAsync<AppActivationStatusDTO>($"AppMandant/{kundeGuid}");
    }

    public async Task<AppActivationStatusDTO> SetMandantStatusByKundeAsync(AppActivationStatusDTO data)
    {
        return await PutAsync<AppActivationStatusDTO>("AppMandant", data);
    }

    public async Task<List<MandantDTO>> GetMandantenAsync()
    {
        return await GetAsync<List<MandantDTO>>("AppMandant/");
    }

    public async Task<List<BenutzerDTO>> GetBenutzerByKundeAsync(Guid kundeGuid)
    {
        return await GetAsync<List<BenutzerDTO>>($"AppBenutzer/{kundeGuid}");
    }

    public async Task<BenutzerDTO> GetOneBenutzerByKundeAsync(Guid kundeGuid, string email)
    {
        var templist = await GetAsync<List<BenutzerDTO>>($"AppBenutzer/{kundeGuid}");
        return templist.FirstOrDefault(x => x.EmailAdresse == email);
    }

    public async Task<MandantDTO> CreateOrUpdateMandantAsync(MandantDTO data)
    {
        return await PutAsync<MandantDTO>("Mandanten", data);
    }

    public async Task<BenutzerDTO> CreateOrUpdateBenutzerByKundeAsync(Guid kundeGuid, BenutzerDTO data, bool pwSenden = false, string passwort = "")
    {
        return await PostAsync<BenutzerDTO>($"AppBenutzer/?kundeGuid={kundeGuid}&pwSenden={pwSenden}&passwort={passwort}", data);
    }

    public async Task DeleteBenutzerByKundeAsync(Guid kundeGuid, BenutzerDTO data)
    {
        await DeleteAsync($"AppBenutzer/?kundeGuid={kundeGuid}&benutzerGuid={data.BenutzerGuid}");
    }

    public async Task AktiviereMandantAsync(string adminEmail)
    {
        await PostAsync("ProduzentAktivieren", new ProduzentAktivierenDTO
        {
            AdminEmail = adminEmail
        }, null, true);
    }
}
