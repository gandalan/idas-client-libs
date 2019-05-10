using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduktFamilienWebRoutinen : WebRoutinenBase
    {
        public ProduktFamilienWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        
        public ProduktFamilieDTO[] GetAll(bool includeVarianten)
        {
            if (Login())
            {
                return Get<ProduktFamilieDTO[]>("ProduktFamilie?includeVarianten=" + includeVarianten.ToString() + "&includeUIDefs=" + includeVarianten.ToString() + "&maxLevel=99");
            }
            return null;
        }

        public string Save(ProduktFamilieDTO dto)
        {
            if (Login())
            {
                return Put("ProduktFamilie/" + dto.ProduktFamilieGuid.ToString(), dto);
            }
            return null;
        }


        public async Task SaveAsync(ProduktFamilieDTO dto)
        {
            await Task.Run(() => Save(dto));
        }

        public async Task<ProduktFamilieDTO[]> GetAllAsync(bool includeVarianten = true)
        {
            return await Task.Run(() => GetAll(includeVarianten));
        }
    }
}
