using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.Contracts.ReportData;

public interface IProduktionsDatenReportData
{
    IPositionsDatenReportData PositionsDaten { get; set; }
    List<IMaterialbedarfReportData> Material { get; set; }
    List<IMaterialbedarfReportData> Packliste { get; set; }
    List<IMaterialbedarfReportData> Saegeliste { get; set; }
    List<IEtikettReportData> Etiketten { get; set; }
    List<IBearbeitungReportData> Bearbeitungen { get; set; }
}