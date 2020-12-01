using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FarbenWebRoutinen : WebRoutinenBase
    {
        public FarbenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public FarbeDTO[] GetAll()
        {
            if (Login())
            {
                return Get<FarbeDTO[]>("Farben");
            }
            return null;
        }

        public string SaveFarbItem(FarbeDTO dto)
        {
            if (Login())
            {
                return Put("Farben/" + dto.FarbItemGuid.ToString(), dto);
            }
            return null;
        }


        public async Task<FarbeDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task<FarbeDTO[]> HTTPGetAllAsync()
        {
            if (HTTPLogin() != null)
                return await HTTPGet<FarbeDTO[]>("Farben");

            return null;
        }

        public async Task SaveFarbItemAsync(FarbeDTO dto)
        {
            await Task.Run(() => SaveFarbItem(dto));
        }
    }
}
