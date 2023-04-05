using System;

namespace Gandalan.IDAS.WebApi.DTO.DTOs.Reports
{
    public class ReportDTO
    {
        public Guid ReportGuid { get; set; }
        public string ReportFile { get; set; }
        public string ReportName { get; set; }
        public ReportTypeDTO ReportType { get; set; }

        public ReportDatenTypDTO ReportDatenTyp { get; set; }
        public bool IsList { get; set; }

        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
        public bool IsCoreReport { get; set; }
    }
}
