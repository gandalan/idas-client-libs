using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduzentenFarbGruppenWebRoutinen : WebRoutinenBase
    {
        public ProduzentenFarbGruppenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public ProduzentenFarbGruppeDTO[] GetAll()
        {
            if (Login())
            {
                return Get<ProduzentenFarbGruppeDTO[]>("ProduzentenFarbGruppen");
            }
            return null;
        }

        public string SaveProduzentenFarbGruppe(ProduzentenFarbGruppeDTO dto)
        {
            if (Login())
            {
                return Put("ProduzentenFarbGruppen/" + dto.ProduzentenFarbGruppeGuid, dto);
            }
            return null;
        }

        public void DeleteProduzentenFarbGruppe(Guid produzentenFarbGruppeGuid)
        {
            if (Login())
            {
                Delete("ProduzentenFarbGruppen/" + produzentenFarbGruppeGuid);
            }
        }


        public async Task<ProduzentenFarbGruppeDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task SaveProduzentenFarbGruppeAsync(ProduzentenFarbGruppeDTO dto)
        {
            await Task.Run(() => SaveProduzentenFarbGruppe(dto));
        }
        public async Task DeleteProduzentenFarbGruppeAsync(Guid produzentenFarbGruppeGuid)
        {
            await Task.Run(() => DeleteProduzentenFarbGruppe(produzentenFarbGruppeGuid));
        }
    }
}
