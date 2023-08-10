using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.Contracts.ReportData
{
    public interface IPositionsDatenReportData
    {
        Guid PositionsDatenGuid { get; set; }
        string VariantenName { get; set; }
        string ArtikelNummer { get; set; }
        int PositionsNummer { get; set; }
        int AlternativPositionZuNummer { get; set; }
        string Besonderheiten { get; set; }
        string Einbauort { get; set; }
        decimal Menge { get; set; }
        string MengenEinheit { get; set; }
        string BelegKommission { get; set; }
        string PositionsKommission { get; set; }
        string Text { get; set; }
        string AngebotsText { get; set; }
        string SonderwunschText { get; set; }
        string SonderwunschAngebotsText { get; set; }
        DateTime ErfassungsDatum { get; set; }
        float BmBreite { get; set; }
        float BmHoehe { get; set; }
        string FarbKuerzel { get; set; }
        Guid FarbKuerzelGuid { get; set; }
        string FarbItem { get; set; }
        Guid FarbItemGuid { get; set; }
        string FarbCode { get; set; }
        string FarbBezeichnung { get; set; }
        string OberflaecheBezeichnung { get; set; }
        Guid OberflaecheGuid { get; set; }
        bool IstSonderFarbPosition { get; set; }
        string Gewebe { get; set; }

        DateTime LieferDatum { get; set; }
        string Serie { get; set; }
        string PCode { get; set; }
        string VorgangsNummer { get; set; }
        string DruckDatum { get; set; }
        string VersandAdresse { get; set; }

        string DataErstellDatum { get; set; }
        string BelegNummer { get; set; }
        string BelegJahr { get; set; }
        string Breite { get; set; }
        string Hoehe { get; set; }
        string Oeffnungsrichtung { get; set; }
        string Farbe { get; set; }
    }
}
