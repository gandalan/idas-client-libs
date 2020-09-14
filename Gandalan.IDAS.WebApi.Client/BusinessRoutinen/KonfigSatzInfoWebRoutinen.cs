using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class KonfigSatzInfoWebRoutinen : WebRoutinenBase
    {
        public KonfigSatzInfoWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public KonfigSatzInfoDTO[] GetAll()
        {
            if (Login())
            {
                return Get<KonfigSatzInfoDTO[]>("KonfigSatzInfo");
            }
            return null;
        }


        public string Save(KonfigSatzInfoDTO dto)
        {
            if (Login())
            {
                return Put("KonfigSatzInfo", dto);
            }
            return null;
        }


        public async Task<KonfigSatzInfoDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public async Task SaveAsync(KonfigSatzInfoDTO dto)
        {
            await Task.Run(() => Save(dto));
        }
    }
}
