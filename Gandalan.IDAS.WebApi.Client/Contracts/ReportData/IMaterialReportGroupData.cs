using System.Collections.Generic;

namespace Gandalan.IDAS.Client.Contracts.Contracts.ReportData;

public interface IMaterialReportGroupData
{
    string ItemName { get; set; }
    byte[] Image { get; set; }
    string Filename { get; set; }
    Dictionary<string, int> FarbeRGB { get; set; }
    List<IMaterialReportItem> Material { get; set; }
}

public class MaterialReportGroupData : IMaterialReportGroupData
{
    public string ItemName { get; set; } = "";
    public byte[] Image { get; set; }
    public string Filename { get; set; }
    public Dictionary<string, int> FarbeRGB { get; set; } = [];
    public List<IMaterialReportItem> Material { get; set; } = [];
}