using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class KonfigSatzWebRoutinen : WebRoutinenBase
    {
        public KonfigSatzWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public KonfigSatzDTO[] GetAll()
        {
            if (Login())
            {
                return Get<KonfigSatzDTO[]>("KonfigSatz");
            }
            return null;
        }


        public string Save(KonfigSatzDTO dto)
        {
            if (Login())
            {
                return Put("KonfigSatz", dto);
            }
            return null;
        }


        public async Task<KonfigSatzDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public async Task SaveAsync(KonfigSatzDTO dto)
        {
            await Task.Run(() => Save(dto));
        }
    }
}
