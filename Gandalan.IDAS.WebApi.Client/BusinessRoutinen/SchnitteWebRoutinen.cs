using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class SchnitteWebRoutinen : WebRoutinenBase
    {
        public SchnitteWebRoutinen(IWebApiConfig settings) : base(settings)
        {
            this.Settings.Url = this.Settings.Url.Replace("/api/", "/ModellDaten/");
        }

        public SchnittDTO[] GetAll()
        {
            if (Login())
            {
                return Get<SchnittDTO[]>("Schnitt");
            }
            return null;
        }

        public string SaveSchnitt(SchnittDTO dto)
        {
            if (Login())
            {
                return Put("Schnitt", dto);
            }
            return null;
        }


        public async Task<SchnittDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public async Task SaveSchnittAsync(SchnittDTO dto)
        {
            await Task.Run(() => SaveSchnitt(dto));
        }
    }
}
