using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IVariantenService
    {
        Task<VarianteDTO[]> GetAllAsync();
        Task<VarianteDTO> LoadAsync(Guid guid);
        Task SaveAsync(VarianteDTO variante);
        Task<ProduktFamilieDTO> GetProduktFamilie(Guid guid);
        Task<ProduktGruppeDTO> GetProduktGruppe(Guid guid);
        Task<VarianteDTOListe> GetVariantenListe(DateTime stichtag);
        Task<ProduktFamilieDTO> GetProduktfamilieZuWarenGruppe(Guid warenGruppeGuid);
    }
}
