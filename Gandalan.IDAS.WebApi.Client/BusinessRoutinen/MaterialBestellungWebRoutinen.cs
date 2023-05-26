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

        public async Task ErzeugeVorgangBeiBeschichterAsync(VorgangDTO vorgang, Guid mGuid, string produzentenKundenNummer) 
            => await PutAsync($"MaterialBestellung?mGuid={mGuid}&produzentenKundenNummer={produzentenKundenNummer}", vorgang);

        public async Task ErzeugeBestellVorgang(VorgangDTO vorgang) 
            => await PutAsync($"MaterialBestellung/BestellungSpeichern", vorgang);

        public async Task ErzeugeReklamationBeiBeschichterAsync(VorgangDTO vorgang, Guid quellVorgang, Guid mGuid, string produzentenKundenNummer) 
            => await PutAsync($"MaterialBestellungReklamation?quellVorgangGuid={quellVorgang}&mGuid={mGuid}&produzentenKundenNummer={produzentenKundenNummer}", vorgang);

        public async Task UpdateStatusBeimProduzentenAsync(Guid vorgangGuid, string status, string externeReferenz = "") 
            => await PostAsync($"MaterialBestellungStatus?vorgangGuid={vorgangGuid}&status={status}&externeReferenz={externeReferenz}", null);

        public async Task<BaseListItemDTO[]> GetAll(int jahr) 
            => await GetAsync<BaseListItemDTO[]>($"MaterialBestellungen/?jahr={jahr}");

        public async Task<BaseListItemDTO[]> GetAll() 
            => await GetAsync<BaseListItemDTO[]>("MaterialBestellungen");
    }
}
