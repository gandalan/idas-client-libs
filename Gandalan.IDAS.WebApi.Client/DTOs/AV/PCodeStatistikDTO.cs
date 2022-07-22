using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV
{
    public class PCodeStatistikDTO
    {
        public Guid MandantGuid { get; set; }
        public string MandantName { get; set; }
        public int UsedPCodes { get; set; }
    }
}
