using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class KontaktWebRoutinen : WebRoutinenBase
    {
        public KontaktWebRoutinen(IWebApiConfig settings) : base(settings) { }

        public KontaktListItemDTO[] GetKontakte()
        {
            if (Login())
                return Get<KontaktListItemDTO[]>("Kontakt");
            throw new Exception("Login fehlgeschlagen");
        }
        public KontaktListItemDTO[] GetKontakte(DateTime? changedSince)
        {
            if (Login())
                if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
                    return Get<KontaktListItemDTO[]>($"Kontakt?changedSince={changedSince.Value.ToString("yyyy-MM-ddTHH:mm:ss")}");
                else
                    return Get<KontaktListItemDTO[]>("Kontakt");
            throw new Exception("Login fehlgeschlagen");
        }
        public KontaktDTO GetKontakt(Guid kontaktGuid)
        {
            if (Login())
                return Get<KontaktDTO>($"Kontakt/{kontaktGuid}");
            throw new Exception("Login fehlgeschlagen");
        }
        public KontaktDTO SaveKontakt(KontaktDTO kontakt)
        {
            if (Login())
                return Put<KontaktDTO>("Kontakt", kontakt);
            throw new Exception("Login fehlgeschlagen");
        }
        public async Task<KontaktListItemDTO[]> GetKontakteAsync() => await Task.Run(() => GetKontakte());
        public async Task<KontaktListItemDTO[]> GetKontakteAsync(DateTime? changedSince) => await Task.Run(() => GetKontakte(changedSince));
        public async Task<KontaktDTO> SaveKontaktAsync(KontaktDTO kontakt) => await Task.Run(() => SaveKontakt(kontakt));
        public async Task<KontaktDTO> GetKontaktAsync(Guid kontaktGuid) => await Task.Run(() => GetKontakt(kontaktGuid));
    }
}
