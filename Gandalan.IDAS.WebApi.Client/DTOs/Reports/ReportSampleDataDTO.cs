using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO.DTOs.Reports
{
    public class ReportSampleDataDTO
    {
        public Guid ReportSampleDataGuid { get; set; }
        public string SampleData { get; set; }
        public string Beschreibung { get; set; }

        public ReportDatenTypDTO ReportDatenTyp { get; set; }
        public ReportTypeDTO ReportType { get; set; }

        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
