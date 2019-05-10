using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO.DTOs.Reports
{
    public class ReportDTO
    {
        public Guid ReportGuid { get; set; }
        public string ReportFile { get; set; }
        public string ReportName { get; set; }

        public ReportDatenTypDTO ReportDatenTyp { get; set; }

        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
