using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Reports.SerienMaterialliste;

public class SerienMateriallisteZuschnittGroupReportDataDTO
{
    public string Serie { get; set; }
    [Obsolete("Use ProduktionsFarbText instead")]
    public string Farbe { get; set; }
    public string ProduktionsFarbText { get; set; }
    public List<SerienMateriallisteZuschnittReportDataDTO> ZuschnittItems { get; set; }
    public string SerieKuerzel { get; set; }
}