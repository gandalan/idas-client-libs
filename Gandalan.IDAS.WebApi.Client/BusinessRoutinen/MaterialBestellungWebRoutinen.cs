using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;
using System.Diagnostics;
using Gandalan.IDAS.WebApi.Client.Settings;
using System.Threading.Tasks;
using System;
using Gandalan.IDAS.Client.Contracts.Contracts;

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
            if (Login())
            {
                return await PutAsync($"MaterialBestellung?mGuid={mGuid}&produzentenKundenNummer={produzentenKundenNummer}", vorgang);
            }
            return null;
        }
        public string UpdateStatusBeimProduzenten(List<string> pCodes, Guid mGuid, string status, string externeReferenz = "")
        {
            if(Login())
            {
                return Post($"MaterialBestellungStatus?mGuid={mGuid}&status={status}&externeReferenz={externeReferenz}", pCodes);
            }
            return null;
        }
        public async Task<string> UpdateStatusBeimProduzentenAsync(List<string> pCodes, Guid mGuid, string status, string externeReferenz = "")
        {
            if (Login())
            {
                return await PostAsync($"MaterialBestellungStatus?mGuid={mGuid}&status={status}&externeReferenz={externeReferenz}", pCodes);
            }
            return null;
        }
        public BaseListItemDTO[] GetAll(int jahr)
        {
            if (Login())
            {
                return Get<BaseListItemDTO[]>($"MaterialBestellungen/?jahr={jahr}");
            }
            return null;
        }
        public BaseListItemDTO[] GetAll()
        {
            if (Login())
            {
                return Get<BaseListItemDTO[]>("MaterialBestellungen");
            }
            return null;
        }
    }
}
