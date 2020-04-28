using System.Collections.Generic;

namespace Gandalan.IDAS.Client.Contracts.Contracts.ReportData
{
    public interface IMaterialReportDataItem
    {
        string ZuschnittWinkel { get; set; }
        string KatalogNummer { get; set; }
        string FarbCode { get; set; }
        string FarbKuerzel { get; set; }
        string FarbBezeichnung { get; set; }
        byte[] Image { get; set; }
        string Filename { get; set; }
        Dictionary<string, int> FarbeRGB { get; set; }
        List<IMaterialReportDataListItem> Material { get; set; }
    }
}
