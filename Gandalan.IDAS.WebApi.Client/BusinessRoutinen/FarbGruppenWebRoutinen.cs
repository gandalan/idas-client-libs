using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FarbGruppenWebRoutinen : WebRoutinenBase
    {
        public FarbGruppenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public FarbGruppeDTO[] GetAll()
        {
            if (Login())
            {
                return Get<FarbGruppeDTO[]>("FarbGruppen");
            }
            return null;
        }

        public string SaveFarbItemGroup(FarbGruppeDTO dto)
        {
            if (Login())
            {
                return Put("FarbGruppen/" + dto.FarbItemGroupGuid.ToString(), dto);
            }
            return null;
        }


        public async Task<FarbGruppeDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task SaveFarbItemAsync(FarbGruppeDTO dto)
        {
            await Task.Run(() => SaveFarbItemGroup(dto));
        }
    }
}
