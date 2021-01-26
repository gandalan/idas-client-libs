using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;
using System.Diagnostics;
using Gandalan.IDAS.WebApi.Client.Settings;
using System.Threading.Tasks;
using System;
using Gandalan.IDAS.Client.Contracts.Contracts;
using System.Net.Http;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client
{
    public class MaterialBestellungWebRoutinen : WebRoutinenBase
    {
        public MaterialBestellungWebRoutinen(IWebApiConfig settings) : base(settings)
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
        public async Task<UserAuthTokenDTO> HTTPErzeugeVorgangBeiBeschichterAsync(string json, Guid mGuid, string produzentenKundenNummer)
        {
            if (HTTPLogin() != null)
                return JsonConvert.DeserializeObject<UserAuthTokenDTO>(await HTTPSendDataAsync(HttpMethod.Put, $"MaterialBestellung?mGuid={mGuid}&produzentenKundenNummer={produzentenKundenNummer}", json));

            return null;
        }
        public string UpdateStatusBeimProduzenten(List<string> pCodes, Guid mGuid, string status)
        {
            if(Login())
            {
                return Post($"MaterialBestellungStatus?mGuid={mGuid}&status={status}", pCodes);
            }
            return null;
        }
        public async Task<string> UpdateStatusBeimProduzentenAsync(List<string> pCodes, Guid mGuid, string status)
        {
            return await Task.Run(() => UpdateStatusBeimProduzenten(pCodes, mGuid, status));
        }
    }
}
