using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Web;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class VariantenWebRoutinen : WebRoutinenBase
    {
        public VariantenWebRoutinen(IWebApiConfig settings) : base(settings) { }

        public VarianteDTO[] GetAll()
        {
            if (Login())
                return Get<VarianteDTO[]>("Variante?includeUIDefs=true&maxLevel=99");
            throw new ApiException("Login fehlgeschlagen");
        }

        public VarianteDTO Get(Guid varianteGuid, bool includeUIDefs = true)
        {
            if (Login())
                return Get<VarianteDTO>($"Variante/{varianteGuid}?includeUIDefs={includeUIDefs}&maxLevel=99");
            throw new ApiException("Login fehlgeschlagen");
        }

        public VarianteDTO SaveVariante(VarianteDTO variante)
        {
            if (Login())
                return Put<VarianteDTO>($"Variante/{variante.VarianteGuid}", variante);
            throw new ApiException("Login fehlgeschlagen");
        }
        public async Task<VarianteDTO[]> GetAllAsync() => await Task.Run(() => GetAll());
        public async Task<VarianteDTO> SaveVarianteAsync(VarianteDTO variante) => await Task.Run(() => SaveVariante(variante));

        public string CacheWebJob()
        {
            return Post("Variante/CacheWebJob", null);
        }

        [Obsolete("Funktion 'SaveVariante()' verwenden")]
        public string Save(VarianteDTO dto)
        {
            if (Login())
            {
                return Put("Variante/" + dto.VarianteGuid.ToString(), dto);
            }
            return null;
        }
        [Obsolete("Funktion 'SaveVarianteAsync()' verwenden")]
        public async Task SaveAsync(VarianteDTO dto)
        {
            await Task.Run(() => Save(dto));
        }
    }
}
