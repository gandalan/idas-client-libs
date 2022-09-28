using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV
{
    public class BelegPositionStatusDTO
    {
        public Guid BelegPositionGuid { get; set; }

        public bool AVPosAnzahlPruefen { get; set; }

        public bool AVDatenBerechnen { get; set; }

        public DateTime ChangedDate { get; set; }
    }
}
