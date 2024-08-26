using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices;

public interface IFarbService
{
    Task<FarbGruppeDTO[]> GetFarbGruppen();
    Task<FarbKuerzelDTO[]> GetFarbKuerzel();
    Task<FarbKuerzelDTO[]> GetFarbKuerzel(ProduktFamilieDTO familie);
    Task<FarbKuerzelDTO[]> GetFarbKuerzel(KatalogArtikelDTO artikel);
    Task<FarbeDTO[]> GetFarben();
    Task<OberflaecheDTO[]> GetOberflaechen();
}