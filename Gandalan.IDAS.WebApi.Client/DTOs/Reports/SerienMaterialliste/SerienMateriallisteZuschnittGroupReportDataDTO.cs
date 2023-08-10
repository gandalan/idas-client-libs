using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Reports.SerienMaterialliste
{
    public class SerienMateriallisteZuschnittGroupReportDataDTO
    {
        public string Serie { get; set; }
        public string Farbe { get; set; }
        public List<SerienMateriallisteZuschnittReportDataDTO> ZuschnittItems { get; set; }
    }
}
