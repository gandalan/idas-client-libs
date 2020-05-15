using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;
using System.Diagnostics;
using Gandalan.IDAS.WebApi.Client.Settings;
using System.Threading.Tasks;
using System;

namespace Gandalan.IDAS.WebApi.Client
{
    public class MaterialBestellungWebRoutinen : WebRoutinenBase
    {
        public MaterialBestellungWebRoutinen(WebApiSettings settings) : base(settings)
        {            
        }
        
        public string ErzeugeVorgangBeiBeschichter(VorgangDTO vorgang, Guid mGuid, string produzentenKundenNummer)
        {
            if (Login())
            {
                return Put($"MaterialBestellung?mGuid={mGuid}&produzentenKundenNummer={produzentenKundenNummer}", vorgang);                
            }
            return null;
        }

        public async Task<string> ErzeugeVorgangBeiBeschichterAsync(VorgangDTO vorgang, Guid mGuid, string produzentenKundenNummer)
        {
            return await Task.Run(() => ErzeugeVorgangBeiBeschichter(vorgang, mGuid, produzentenKundenNummer));
        }

    }
}
