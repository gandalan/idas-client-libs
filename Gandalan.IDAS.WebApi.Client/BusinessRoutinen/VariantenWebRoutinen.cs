using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class VariantenWebRoutinen : WebRoutinenBase
    {
        public VariantenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public VarianteDTO[] GetAll()
        {
            if (Login())
            {
                return Get<VarianteDTO[]>("Variante?includeUIDefs=true&maxLevel=99");
            }
            return null;
        }


        public string Save(VarianteDTO dto)
        {
            if (Login())
            {
                return Put("Variante/" + dto.VarianteGuid.ToString(), dto);
            }
            return null;
        }


        public async Task<VarianteDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public async Task SaveAsync(VarianteDTO dto)
        {
            await Task.Run(() => Save(dto));
        }
    }
}
