using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class MaterialBearbeitungenWebRoutinen : WebRoutinenBase
    {
        public MaterialBearbeitungenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public MaterialBearbeitungsMethodeDTO[] GetAll()
        {
            if (Login())
            {
                return Get<MaterialBearbeitungsMethodeDTO[]>("MaterialBearbeitungsMethoden");
            }
            return null;
        }

        public string SaveMethode(MaterialBearbeitungsMethodeDTO dto)
        {
            bool flag = base.Login();
            string result;
            if (flag)
            {
                result = base.Put("MaterialBearbeitungsMethoden", dto, null);
            }
            else
            {
                result = null;
            }
            return result;
        }


        public async Task<MaterialBearbeitungsMethodeDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public async Task SaveMethodeAsync(MaterialBearbeitungsMethodeDTO dto)
        {
            await Task.Run(() => SaveMethode(dto));
        }
    }
}
