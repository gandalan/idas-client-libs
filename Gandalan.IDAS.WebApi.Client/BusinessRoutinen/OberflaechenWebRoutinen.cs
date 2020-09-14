using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class OberflaechenWebRoutinen : WebRoutinenBase
    {
        public OberflaechenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public OberflaecheDTO[] GetAll()
        {
            if (Login())
            {
                return Get<OberflaecheDTO[]>("Oberflaeche");
            }
            return null;
        }

        public string SaveOberflaeche(OberflaecheDTO dto)
        {
            if (Login())
            {
                return Put("Oberflaeche/" + dto.OberflaecheGuid, dto);
            }
            return null;
        }


        public async Task<OberflaecheDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task SaveOberflaecheAsync(OberflaecheDTO dto)
        {
            await Task.Run(() => SaveOberflaeche(dto));
        }
    }
}
