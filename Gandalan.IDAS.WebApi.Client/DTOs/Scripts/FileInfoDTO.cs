using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class FileInfoDTO
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public DateTime? GueltigBis { get; set; }
    }
}
