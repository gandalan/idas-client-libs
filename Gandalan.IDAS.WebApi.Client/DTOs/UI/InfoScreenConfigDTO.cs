using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// DTO für Konfiguration der InfoScreens
    /// </summary>
    public class InfoScreenConfigDTO
    {
        public Guid InfoScreenGuid { get; set; }

        public DateTime ChangedDate { get; set; }

        public string Caption { get; set; }

        public string Layout { get; set; } = "einspaltig";

        public string Initiator { get; set; }

        public Type ParamType { get; set; }

        public List<InfoScreenRowDTO> Rows { get; set; }
    }
}
