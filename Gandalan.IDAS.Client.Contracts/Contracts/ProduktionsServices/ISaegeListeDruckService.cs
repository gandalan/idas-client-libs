using Gandalan.IDAS.Client.Contracts.Contracts.ReportData;
using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface ISaegeListeDruckService {
        Task Prepare(List<BelegPositionAVDTO> reportData);
        Task Prepare(List<MaterialBeschaffungsJobDTO> reportData);
        List<IMaterialReportData> GetData(); //returns calculated data
        void Print(List<IMaterialReportData> reportData);
    }
}