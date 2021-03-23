using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Web;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduktFamilienWebRoutinen : WebRoutinenBase
    {
        public ProduktFamilienWebRoutinen(IWebApiConfig settings) : base(settings) { }
       
        public ProduktFamilieDTO[] GetAll(bool includeVarianten)
        {
            if (Login())
                return Get<ProduktFamilieDTO[]>($"ProduktFamilie?includeVarianten={includeVarianten}&includeUIDefs={includeVarianten}&maxLevel=99");
            throw new ApiException("Login fehlgeschlagen");
        }
        public ProduktFamilieDTO SaveProduktFamilie(ProduktFamilieDTO produktFamilie)
        {
            if (Login())
                return Put<ProduktFamilieDTO>($"ProduktFamilie/{produktFamilie.ProduktFamilieGuid}", produktFamilie);
            throw new ApiException("Login fehlgeschlagen");
        }
        public async Task SaveProduktFamilieAsync(ProduktFamilieDTO produktFamilie) => await Task.Run(() => SaveProduktFamilie(produktFamilie));
        public async Task<ProduktFamilieDTO[]> GetAllAsync(bool includeVarianten = true) => await Task.Run(() => GetAll(includeVarianten));

        [Obsolete("Funktion 'SaveProduktFamilie()' verwenden")]
        public string Save(ProduktFamilieDTO dto)
        {
            if (Login())
            {
                return Put("ProduktFamilie/" + dto.ProduktFamilieGuid.ToString(), dto);
            }
            return null;
        }
        [Obsolete("Funktion 'SaveProduktFamilieAsync()' verwenden")]
        public async Task SaveAsync(ProduktFamilieDTO dto)
        {
            await Task.Run(() => Save(dto));
        }
    }
}
