﻿namespace Gandalan.IDAS.WebApi.Client.DTOs.Reports.SerienMaterialliste
{
    public class SerienMateriallisteZubehoerReportDataDTO
    {
        public string Serie { get; set; }
        public string Katalognummer { get; set; }
        public string Farbkuerzel { get; set; }
        public string FarbBezeichnung { get; set; }
        public string FarbCode { get; set; }
        public int Anzahl { get; set; }
        public decimal Laufmeter { get; set; }
        public string Einheit { get; set; }
        public string Bezeichnung { get; set; }
        public string OberflaecheBezeichnung { get; set; }
    }
}
