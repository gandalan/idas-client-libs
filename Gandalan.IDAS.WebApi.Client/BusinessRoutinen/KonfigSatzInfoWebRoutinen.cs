using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Web;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class KonfigSatzInfoWebRoutinen : WebRoutinenBase
    {
        public KonfigSatzInfoWebRoutinen(IWebApiConfig settings) : base(settings) { }

        public KonfigSatzInfoDTO[] GetAll()
        {
            if (Login())
                return Get<KonfigSatzInfoDTO[]>("KonfigSatzInfo");
            throw new ApiException("Login fehlgeschlagen");
        }

        public KonfigSatzInfoDTO SaveKonfigSatzInfo(KonfigSatzInfoDTO konfigSatzInfo)
        {
            if (Login())
                return Put<KonfigSatzInfoDTO>("KonfigSatzInfo", konfigSatzInfo);
            throw new ApiException("Login fehlgeschlagen");
        }
        public async Task SaveKonfigSatzInfoAsync(KonfigSatzInfoDTO konfigSatzInfo) => await Task.Run(() => SaveKonfigSatzInfo(konfigSatzInfo));
        public async Task<KonfigSatzInfoDTO[]> GetAllAsync() => await Task.Run(() => GetAll());

        [Obsolete("Funktion 'SaveKonfigSatzInfo()' verwenden")]
        public string Save(KonfigSatzInfoDTO dto)
        {
            if (Login())
            {
                return Put("KonfigSatzInfo", dto);
            }
            return null;
        }
        [Obsolete("Funktion 'SaveKonfigSatzInfoAsync()' verwenden")]
        public async Task SaveAsync(KonfigSatzInfoDTO dto)
        {
            await Task.Run(() => Save(dto));
        }
    }
}
