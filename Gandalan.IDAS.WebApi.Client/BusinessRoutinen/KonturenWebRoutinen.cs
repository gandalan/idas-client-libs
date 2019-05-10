using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class KonturenWebRoutinen : WebRoutinenBase
    {
        public KonturenWebRoutinen(WebApiSettings settings) : base(settings)
        {
            this.Settings.Url = this.Settings.Url.Replace("/api/", "/ModellDaten/");
        }

        public KonturDTO[] GetAll()
        {
            if (Login())
            {
                return Get<KonturDTO[]>("Kontur");
            }
            return null;
        }

        public string SaveKontur(KonturDTO dto)
        {
            if (Login())
            {
                return Put("Kontur", dto);
            }
            return null;
        }


        public async Task<KonturDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public async Task SaveKonturAsync(KonturDTO dto)
        {
            await Task.Run(() => SaveKontur(dto));
        }
    }
}
