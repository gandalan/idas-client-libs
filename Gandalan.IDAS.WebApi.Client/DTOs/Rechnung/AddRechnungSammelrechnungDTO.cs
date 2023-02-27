using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Rechnung
{
    public class AddRechnungSammelrechnungDTO
    {
        public Guid BelegGuid { get; set; }
        public Guid SammelrechnungGuid { get; set; }
    }
}
