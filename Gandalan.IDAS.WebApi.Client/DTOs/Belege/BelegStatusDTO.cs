using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.Util;
using PropertyChanged;

namespace Gandalan.IDAS.WebApi.DTO
{
    
    public class BelegStatusDTO
    {
        /// <summary>
        /// Eindeutige GUID
        /// </summary>
        public Guid VorgangGuid { get; set; }
        public Guid BelegGuid { get; set; }
        /// <summary>
        /// Sichtbare Vorgangsnummer/zur Info für Kunden usw.
        /// </summary>
        public long VorgangsNummer { get; set; }
        public long BelegNummer { get; set; }
        /// <summary>
        /// Statuscode
        /// </summary>
        public string AktuellerStatus { get; set; }
        /// <summary>
        /// Datum der letzten Änderung des Vorgangs        
        /// </summary>
        public DateTime AenderungsDatum { get; set; }
        public string NeuerStatus { get; set; }
        public string NeuerStatusText { get; set; }
        public string AktuellerStatusText { get; set; }
    }
}
