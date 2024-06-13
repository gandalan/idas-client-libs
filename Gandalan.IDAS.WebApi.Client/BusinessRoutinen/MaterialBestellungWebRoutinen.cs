using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client;

public class MaterialBestellungWebRoutinen : WebRoutinenBase
{
    public MaterialBestellungWebRoutinen(IWebApiConfig settings) : base(settings)
    {
        }

    public async Task<VorgangDTO> ErzeugeVorgangBeiBeschichterAsync(VorgangDTO vorgang, Guid mGuid, string produzentenKundenNummer)
        => await PutAsync<VorgangDTO>($"MaterialBestellung?mGuid={mGuid}&produzentenKundenNummer={produzentenKundenNummer}", vorgang);

    public async Task<VorgangDTO> ErzeugeBestellVorgang(VorgangDTO vorgang)
        => await PutAsync<VorgangDTO>("MaterialBestellung/BestellungSpeichern", vorgang);

    public async Task<VorgangDTO> ErzeugeReklamationBeiBeschichterAsync(VorgangDTO vorgang, Guid quellVorgang, Guid mGuid, string produzentenKundenNummer)
        => await PutAsync<VorgangDTO>($"MaterialBestellungReklamation?quellVorgangGuid={quellVorgang}&mGuid={mGuid}&produzentenKundenNummer={produzentenKundenNummer}", vorgang);

    public async Task UpdateStatusBeimProduzentenAsync(Guid vorgangGuid, string status, string externeReferenz = "")
        => await PostAsync($"MaterialBestellungStatus?vorgangGuid={vorgangGuid}&status={status}&externeReferenz={externeReferenz}", null);

    public async Task<BaseListItemDTO[]> GetAll(int jahr)
        => await GetAsync<BaseListItemDTO[]>($"MaterialBestellungen/?jahr={jahr}");

    public async Task<BaseListItemDTO[]> GetAll()
        => await GetAsync<BaseListItemDTO[]>("MaterialBestellungen");
}