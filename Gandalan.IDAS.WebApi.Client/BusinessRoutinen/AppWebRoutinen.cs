using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using Gandalan.IDAS.WebApi.DTO.API;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class AppWebRoutinen : WebRoutinenBase
    {
        public AppWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public AppActivationStatusDTO GetMandantStatusByKunde(Guid kundeGuid)
        {
            if (Login())
            {
                return Get<AppActivationStatusDTO>($"AppMandant/{kundeGuid.ToString()}");
            }
            return null;
        }

        public AppActivationStatusDTO SetMandantStatusByKunde(AppActivationStatusDTO data)
        {
            if (Login())
            {
                return Put<AppActivationStatusDTO>($"AppMandant", data);
            }
            return null;
        }

        public List<MandantDTO> GetMandanten()
        {
            if (Login())
            {
                return Get<List<MandantDTO>>($"AppMandant/");
            }
            return null;
        }

        public List<BenutzerDTO> GetBenutzerByKunde(Guid kundeGuid)
        {
            if (Login())
            {
                return Get<List<BenutzerDTO>>($"AppBenutzer/{kundeGuid.ToString()}");
            }
            return null;
        }

        public BenutzerDTO GetOneBenutzerByKunde(Guid kundeGuid, string email)
        {
            List<BenutzerDTO> templist = new List<BenutzerDTO>();
            if (Login())
            {
                templist = Get<List<BenutzerDTO>>($"AppBenutzer/{kundeGuid.ToString()}");
                foreach (var benutzer in templist)
                {
                    if (benutzer.EmailAdresse == email)
                    {
                        return benutzer;
                    }
                }
            }
            return null;
        }

        public MandantDTO CreateOrUpdateMandant(MandantDTO data)
        {
            if (Login())
            {
                return Put<MandantDTO>("Mandanten", data);
            }
            return null;
        }

        public BenutzerDTO CreateOrUpdateBenutzerByKunde(Guid kundeGuid, BenutzerDTO data, bool pwSenden = false, string passwort = "")
        {
            if (Login())
            {
                return Post<BenutzerDTO>("AppBenutzer/?kundeGuid=" + kundeGuid.ToString() + "&pwSenden=" + pwSenden + "&passwort=" + passwort, data);
            }
            return null;
        }

        public ExtendedStatusCodeDTO DeleteBenutzerByKunde(Guid kundeGuid, BenutzerDTO data)
        {
            if (Login())
            {
                return Delete<ExtendedStatusCodeDTO>("AppBenutzer/?kundeGuid=" + kundeGuid.ToString() + "&benutzerGuid=" + data.BenutzerGuid);
            }
            return null;
        }

        public string AktiviereMandant(string adminEmail)
        {
            return Post("ProduzentAktivieren", new ProduzentAktivierenDTO()
            {
                AdminEmail = adminEmail
            });
        }


        public async Task<List<BenutzerDTO>> GetBenutzerByKundeAsync(Guid kundeGuid)
        {
            return await Task<List<BenutzerDTO>>.Run(() => { return GetBenutzerByKunde(kundeGuid); });
        }

        public async Task<MandantDTO> CreateOrUpdateMandantAsync(MandantDTO data)
        {
            return await Task<MandantDTO>.Run(() => { return CreateOrUpdateMandant(data); });
        }

        public async Task<ExtendedStatusCodeDTO> DeleteBenutzerByKundeAsync(Guid kundeGuid, BenutzerDTO data)
        {
            return await Task<ExtendedStatusCodeDTO>.Run(() => { return DeleteBenutzerByKunde(kundeGuid, data); });
        }

        public async Task<BenutzerDTO> CreateOrUpdateBenutzerByKundeAsync(Guid kundeGuid, BenutzerDTO data, bool pwSenden = false, string passwort = "")
        {
            return await Task<BenutzerDTO>.Run(() => { return CreateOrUpdateBenutzerByKunde(kundeGuid, data, pwSenden, passwort); });
        }

        public async Task<AppActivationStatusDTO> GetMandantStatusByKundeAsync(Guid kundeGuid)
        {
            return await Task<AppActivationStatusDTO>.Run(() => { return GetMandantStatusByKunde(kundeGuid); });
        }

        public async Task<List<MandantDTO>> GetMandantenAsync()
        {
            return await Task<List<MandantDTO>>.Run(() => { return GetMandanten(); });
        }

        public async Task<AppActivationStatusDTO> SetMandantStatusByKundeAsync(AppActivationStatusDTO data)
        {
            return await Task<AppActivationStatusDTO>.Run(() => { return SetMandantStatusByKunde(data); });
        }
    }
}
