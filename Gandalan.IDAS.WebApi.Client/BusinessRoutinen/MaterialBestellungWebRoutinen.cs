using Gandalan.IDAS.WebApi.DTO;
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
        public async Task<string> ErzeugeBestellVorgang(VorgangDTO vorgang)
        {
            if (Login())
            {
                return await PutAsync($"MaterialBestellung/BestellungSpeichern", vorgang);
            }
            return null;
        }
        public string ErzeugeReklamationBeiBeschichter(VorgangDTO vorgang, Guid quellVorgang, Guid mGuid, string produzentenKundenNummer)
        {
            if (Login())
            {
                return Put($"MaterialBestellungReklamation?quellVorgangGuid={quellVorgang}&mGuid={mGuid}&produzentenKundenNummer={produzentenKundenNummer}", vorgang);
            }
            return null;
        }
        public async Task<string> ErzeugeReklamationBeiBeschichterAsync(VorgangDTO vorgang, Guid quellVorgang, Guid mGuid, string produzentenKundenNummer)
        {
            if (Login())
            {
                return await PutAsync($"MaterialBestellungReklamation?quellVorgangGuid={quellVorgang}&mGuid={mGuid}&produzentenKundenNummer={produzentenKundenNummer}", vorgang);
            }
            return null;
        }

        public string UpdateStatusBeimProduzenten(Guid vorgangGuid, string status, string externeReferenz = "")
        {
            if(Login())
            {
                return Post($"MaterialBestellungStatus?vorgangGuid={vorgangGuid}&status={status}&externeReferenz={externeReferenz}", null);
            }
            return null;
        }
        public async Task<string> UpdateStatusBeimProduzentenAsync(Guid vorgangGuid, string status, string externeReferenz = "")
        {
            if (Login())
            {
                return await PostAsync($"MaterialBestellungStatus?vorgangGuid={vorgangGuid}&status={status}&externeReferenz={externeReferenz}", null);
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
