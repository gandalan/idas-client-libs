using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class AnpassungenWebRoutinen : WebRoutinenBase
    {
        public AnpassungenWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public AnpassungDTO[] GetAll()
        {
            if (Login())
            {
                return Get<AnpassungDTO[]>("Anpassungen");
            }
            return null;
        }

        public string SaveAnpassung(AnpassungDTO dto)
        {
            if (Login())
            {
                return Put("Anpassungen/" + dto.AnpassungGuid, dto);
            }
            return null;
        }

        public void DeleteAnpassung(Guid anpassungGuid)
        {
            if (Login())
            {
                Delete("Anpassungen/" + anpassungGuid);
            }
        }

        public async Task<AnpassungDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task SaveAnpassungAsync(AnpassungDTO dto)
        {
            await Task.Run(() => SaveAnpassung(dto));
        }
        public async Task DeleteAnpassungAsync(Guid anpassungGuid)
        {
            await Task.Run(() => DeleteAnpassung(anpassungGuid));
        }
    }
}
