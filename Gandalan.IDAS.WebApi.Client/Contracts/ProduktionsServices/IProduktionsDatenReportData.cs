using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IProduktionsDatenReportData
    {
        PositionsDatenDTO PositionsDaten { get; set; }
        List<MaterialbedarfDTO> Material { get; set; }
        List<MaterialbedarfDTO> Packliste { get; set; }
        List<MaterialbedarfDTO> Saegeliste { get; set; }
        List<EtikettDTO> Etiketten { get; set; }
        List<BearbeitungDTO> Bearbeitungen { get; set; }
    }
}
