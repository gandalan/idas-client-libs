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

    public class MaterialReportDataItem : IMaterialReportDataItem
    {
        public string ZuschnittWinkel { get; set; }
        public string KatalogNummer { get; set; }
        public string FarbCode { get; set; }
        public string FarbKuerzel { get; set; } = "Kuerzel";
        public string FarbBezeichnung { get; set; } = "Farbbezeichnung";
        public byte[] Image { get; set; }
        public string Filename { get; set; }
        //public Color Farbe { get; set; } = "50, 220, 180";
        public Dictionary<string, int> FarbeRGB { get; set; } = new Dictionary<string, int>();
        public List<IMaterialReportDataListItem> Material { get; set; } = new List<IMaterialReportDataListItem>();
    }
}
