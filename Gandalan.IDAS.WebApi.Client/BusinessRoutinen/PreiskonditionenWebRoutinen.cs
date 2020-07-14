using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class PreiskonditionenWebRoutinen : WebRoutinenBase
    {
        public PreiskonditionenWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public string SavePreiskonditionen(string konditionen)
        {
            if (Login())
            {
                return Put<string>("Preiskonditionen/", konditionen);
            }
            return null;
        }

        public async Task SavePreiskonditionenAsync(string konditionen)
        {
            await Task.Run(() => SavePreiskonditionen(konditionen));
        }
    }
}
