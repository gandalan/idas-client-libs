using System.Collections.Generic;

namespace Gandalan.IDAS.Client.Contracts.Contracts.ReportData
{
    public interface IMaterialReportDataItem
    {
        string ItemName { get; set; }
        byte[] Image { get; set; }
        string Filename { get; set; }
        Dictionary<string, int> FarbeRGB { get; set; }
        List<IMaterialReportDataListItem> Material { get; set; }
    }

    public class MaterialReportDataItem : IMaterialReportDataItem
    {
        public string ItemName { get; set; } = "";
        public byte[] Image { get; set; }
        public string Filename { get; set; }
        public Dictionary<string, int> FarbeRGB { get; set; } = new Dictionary<string, int>();
        public List<IMaterialReportDataListItem> Material { get; set; } = new List<IMaterialReportDataListItem>();
    }
}
