using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class KontaktWebRoutinen : WebRoutinenBase
    {
        public KontaktWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public KontaktListItemDTO[] GetKontakte()
        {
            if (Login())
            {
                return Get<KontaktListItemDTO[]>("Kontakt");
            }
            return null;
        }

        public KontaktListItemDTO[] GetKontakte(DateTime? changedSince)
        {
            if (Login())
            {
                if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
                {
                    return Get<KontaktListItemDTO[]>("Kontakt?changedSince=" + changedSince.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
                }
                else
                {
                    return Get<KontaktListItemDTO[]>("Kontakt");
                }
            }
            return null;
        }

        public KontaktDTO GetKontakt(Guid kontaktGuid)
        {
            if (Login())
            {
                return Get<KontaktDTO>("Kontakt/" + kontaktGuid);
            }
            return null;
        }
                
        public KontaktDTO SaveKontakt(KontaktDTO data)
        {
            if (Login())
            {
                return Put<KontaktDTO>("Kontakt", data);
            }
            return null;
        }


        public async Task<KontaktListItemDTO[]> GetKontakteAsync()
        {
            return await Task<KontaktListItemDTO[]>.Run(() => { return GetKontakte(); });
        }

        public async Task<KontaktListItemDTO[]> GetKontakteAsync(DateTime? changedSince)
        {
            return await Task<KontaktListItemDTO[]>.Run(() => { return GetKontakte(changedSince); });
        }

        public async Task<KontaktDTO> SaveKontaktAsync(KontaktDTO data)
        {
            return await Task<KontaktDTO>.Run(() => { return SaveKontakt(data); });
        }

        public async Task<KontaktDTO> GetKontaktAsync(Guid kontaktGuid)
        {
            return await Task<KontaktDTO>.Run(() => { return GetKontakt(kontaktGuid); });
        }
    }
}
