using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices;

public interface IVariantenService
{
    Task<VarianteDTO[]> GetAllAsync();
    Task<VarianteDTO> LoadAsync(Guid guid);
    Task SaveAsync(VarianteDTO variante);
    Task<ProduktFamilieDTO> GetProduktFamilie(Guid guid);
    Task<ProduktGruppeDTO[]> GetAllProduktGruppenAsync();
    Task<ProduktGruppeDTO> GetProduktGruppe(Guid guid);
    Task<VarianteDTOListe> GetVariantenListe(DateTime stichtag);
    Task<ProduktFamilieDTO> GetProduktfamilieZuWarenGruppe(Guid warenGruppeGuid);
}