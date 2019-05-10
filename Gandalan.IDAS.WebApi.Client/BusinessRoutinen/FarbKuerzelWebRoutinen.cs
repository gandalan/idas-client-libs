using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FarbKuerzelWebRoutinen : WebRoutinenBase
    {
        public FarbKuerzelWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public FarbKuerzelDTO[] GetAll()
        {
            if (Login())
            {
                return Get<FarbKuerzelDTO[]>("FarbKuerzel");
            }
            return null;
        }

        public string SaveFarbKuerzel(FarbKuerzelDTO dto)
        {
            if (Login())
            {
                return Put("FarbKuerzel/" + dto.FarbKuerzelGuid.ToString(), dto);
            }
            return null;
        }


        public async Task<FarbKuerzelDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task SaveFarbKuerzelAsync(FarbKuerzelDTO dto)
        {
            await Task.Run(() => SaveFarbKuerzel(dto));
        }
    }
}
