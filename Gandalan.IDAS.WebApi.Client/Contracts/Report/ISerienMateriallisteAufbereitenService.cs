using Gandalan.IDAS.WebApi.Client.DTOs.Reports.SerienMaterialliste;
using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Report
{
    public interface ISerienMateriallisteAufbereitenService
    {
        Task<List<SerienMateriallisteZubehoerReportDataDTO>> AufbereitenZubehoer(SerieDTO serie, IList<BelegPositionAVDTO> elemente);
        Task<List<SerienMateriallisteZubehoerReportDataDTO>> AufbereitenZubehoer(VorgangDTO vorgang, IList<BelegPositionAVDTO> elemente);
        Task<List<SerienMateriallisteZubehoerReportDataDTO>> getBySerieZubehoer(SerieDTO serie, IList<BelegPositionAVDTO> elemente);
        Task<List<SerienMateriallisteZuschnittGroupReportDataDTO>> AufbereitenZuschnitt(SerieDTO serie, IList<BelegPositionAVDTO> elemente);
        Task<List<SerienMateriallisteZuschnittGroupReportDataDTO>> AufbereitenZuschnitt(VorgangDTO vorgang, IList<BelegPositionAVDTO> elemente);
        Task<List<SerienMateriallisteZuschnittGroupReportDataDTO>> getBySerieZuschnitt(SerieDTO serie, IList<BelegPositionAVDTO> elemente);
    }
}
