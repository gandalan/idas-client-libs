using Gandalan.IDAS.Client.Contracts.Contracts.ReportData;
using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface ISaegeListeDruckService {
        void Prepare(List<BelegPositionAVDTO> reportData);
        void Prepare(List<MaterialBeschaffungsJobDTO> reportData);
        List<IMaterialReportData> GetData(); //returns calculated data
        void Print(List<IMaterialReportData> reportData);
    }
}