using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Faktura;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class FakturaWebRoutinen : WebRoutinenBase
{
    public FakturaWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<string> GetVorgangKennzeichenAsync(Guid vorgangGuid)
        => await GetAsync<string>($"Faktura/GetVorgangKennzeichen?vorgangGuid={vorgangGuid}");

    public async Task<string> GetBelegKennzeichenAsync(Guid belegGuid)
        => await GetAsync<string>($"Faktura/GetBelegKennzeichen?belegGuid={belegGuid}");

    public async Task<string> GetBelegPositionKennzeichenAsync(Guid belegPositionGuid)
        => await GetAsync<string>($"Faktura/GetBelegPositionKennzeichen?vorgangGuid={belegPositionGuid}");

    public async Task<string> GetBelegPositionAVKennzeichenAsync(Guid belegPositionAvGuid)
        => await GetAsync<string>($"Faktura/GetBelegPositionAVKennzeichen?vorgangGuid={belegPositionAvGuid}");

    public async Task<string> SetVorgangKennzeichenAsync(SetFakturaDTO dto)
        => await PostAsync<string>("Faktura/SetVorgangKennzeichen", dto);

    public async Task<string> SetBelegKennzeichenAsync(SetFakturaDTO dto)
        => await PostAsync<string>("Faktura/SetBelegKennzeichen", dto);

    public async Task<string> SetBelegPositionKennzeichenAsync(SetFakturaDTO dto)
        => await PostAsync<string>("Faktura/SetBelegPositionKennzeichen", dto);

    public async Task<string> SetBelegPositionAVKennzeichenAsync(SetFakturaDTO dto)
        => await PostAsync<string>("Faktura/SetBelegPositionAVKennzeichen", dto);

    public async Task SetFakturaInABAuto()
        => await PostAsync<string>("Faktura/SetFakturaInABAuto", null);
}
