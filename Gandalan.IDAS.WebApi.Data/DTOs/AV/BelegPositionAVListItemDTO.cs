using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class BelegPositionAVListItemDTO
    {
        public Guid BelegPositionAVGuid { get; set; }

        public string PCode { get; set; }

        public DateTime ChangedDate { get; set; }
    }
}
