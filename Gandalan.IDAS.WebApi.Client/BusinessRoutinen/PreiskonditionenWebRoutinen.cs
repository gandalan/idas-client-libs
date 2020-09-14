using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class PreiskonditionenWebRoutinen : WebRoutinenBase
    {
        public PreiskonditionenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public PreisermittlungsEinstellungenDTO GetPreiskonditionen()
        {
            if (Login())
            {
                return Get<PreisermittlungsEinstellungenDTO>($"Preiskonditionen/");
            }
            return null;
        }

        public string SavePreiskonditionen(string konditionen)
        {
            if (Login())
            {
                return Put<string>("Preiskonditionen/", konditionen);
            }
            return null;
        }


        public async Task<PreisermittlungsEinstellungenDTO> GetPreiskonditionenAsync()
        {
            return await Task.Run(() => GetPreiskonditionen());
        }
        public async Task SavePreiskonditionenAsync(string konditionen)
        {
            await Task.Run(() => SavePreiskonditionen(konditionen));
        }
    }
}
