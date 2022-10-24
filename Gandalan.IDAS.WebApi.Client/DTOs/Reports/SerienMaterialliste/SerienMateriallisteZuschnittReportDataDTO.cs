using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Reports.SerienMaterialliste
{
    public class SerienMateriallisteZuschnittReportDataDTO
    {
        public string Katalognummer { get; set; }
        public string FarbKuerzel { get; set; }
        public string FarbCode { get; set; }
        public string FarbBezeichnung { get; set; }
        public decimal Gesamtlaenge { get; set; }
        public decimal PufferLaenge { get; set; }
        public decimal Laenge { get; set; }
        public decimal VerschnittLaenge { get; set; }
        public int StangenCount { get; set; }
        public string StangenLaenge { get; set; }
        public string OberflaecheBezeichnung { get; set; }
    }
}
