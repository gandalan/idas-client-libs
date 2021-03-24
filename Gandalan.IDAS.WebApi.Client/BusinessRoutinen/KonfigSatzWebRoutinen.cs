using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Web;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class KonfigSatzWebRoutinen : WebRoutinenBase
    {
        public KonfigSatzWebRoutinen(IWebApiConfig settings) : base(settings) { }

        public KonfigSatzDTO[] GetAll()
        {
            if (Login())
                return Get<KonfigSatzDTO[]>("KonfigSatz");
            throw new ApiException("Login fehlgeschlagen");
        }
        public KonfigSatzDTO SaveKonfigSatz(KonfigSatzDTO konfigSatz)
        {
            if (Login())
                return Put<KonfigSatzDTO>("KonfigSatz", konfigSatz);
            throw new ApiException("Login fehlgeschlagen");
        }
        public async Task SaveKonfigSatzAsync(KonfigSatzDTO konfigSatz) => await Task.Run(() => SaveKonfigSatz(konfigSatz));
        public async Task<KonfigSatzDTO[]> GetAllAsync() => await Task.Run(() => GetAll());

        [Obsolete("Funktion 'SaveKonfigSatz()' verwenden")]
        public string Save(KonfigSatzDTO konfigSatz)
        {
            if (Login())
                return Put("KonfigSatz", konfigSatz);
            throw new ApiException("Login fehlgeschlagen");
        }
        [Obsolete("Funktion 'SaveKonfigSatzAsync()' verwenden")]
        public async Task SaveAsync(KonfigSatzDTO dto) => await Task.Run(() => Save(dto));
    }
}
