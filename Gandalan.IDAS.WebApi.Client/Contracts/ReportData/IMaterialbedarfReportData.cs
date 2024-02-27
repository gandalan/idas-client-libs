using System;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.Contracts.ReportData
{
    public interface IMaterialbedarfReportData
    {
        Guid MaterialBedarfGuid { get; set; }
        Guid Kennzeichen { get; set; }
        string InternerName { get; set; }
        string InternerName_Backup { get; set; }
        string KatalogNummer { get; set; }
        string Bezeichnung { get; set; }
        string Einheit { get; set; }
        bool Beipacken { get; set; }
        string Vorgangsnummer { get; set; }
        decimal Stueckzahl { get; set; }
        decimal Laufmeter { get; set; }

        bool IstVE { get; set; }

        decimal VE_Menge { get; set; }
        decimal Artikel_VE_Menge { get; set; }
        /// <summary>
        /// Format: <KürzelOderSF> <FarbzusatzTextWennVorhanden> <FarbCode> <Farbbezeichnung> <OberflächeAußerWennSieStandardHeißt>
        /// </summary>
        string ProduktionsFarbText { get; set; }
        string FarbZusatzText { get; set; }
        string FarbBezeichnung { get; set; }
        string FarbKuerzel { get; set; }
        Guid FarbKuerzelGuid { get; set; }
        string FarbCode { get; set; }
        string FarbeItem { get; set; }
        Guid FarbItemGuid { get; set; }

        string OberflaecheBezeichnung { get; set; }
        Guid OberFlaecheGuid { get; set; }
        bool IstZuschnitt { get; set; }
        float ZuschnittLaenge { get; set; }
        string ZuschnittWinkel { get; set; }
        string PositionsAngabe { get; set; }
        string MaterialBezeichnung { get; set; }
        bool MaterialBearbeitungSaegen { get; set; }
        bool MaterialBearbeitungFraesen { get; set; }
        bool MaterialBearbeitungStanzen { get; set; }
        bool MaterialBearbeitungBeschichten { get; set; }
        bool MaterialBearbeitungBohren { get; set; }
        bool MaterialBearbeitungEloxieren { get; set; }
        bool AufPackListe { get; set; }
        string CADKennung { get; set; }
        string EtikettenSonderS { get; set; }
        string IndiSonderInfo1 { get; set; }
        string IndiSonderInfo2 { get; set; }
        string IndiSonderInfo3 { get; set; }
        string PIText { get; set; }
        bool SchraegElement { get; set; }
        string SonderFormInfo { get; set; }
        string ZusatzEtikettText { get; set; }
        bool AufMaterialListe { get; set; }
        bool NurLieferscheinAnzeige { get; set; }
        bool FromSonderWunsch { get; set; }
        bool IstBeschichtbar { get; set; }
        KatalogArtikelArt KatalogArtikelArt { get; set; }
        MaterialbedarfStatiDTO AktuellerStatus { get; set; }
        bool ProfilGedrehtSaegen { get; set; }
        bool IstSonderfarbe { get; set; }
        string MaterialPCode { get; set; }
        string Bemerkung { get; set; }
        Guid? AVPositionGuid { get; set; }
        Guid ZielKennzeichen { get; set; }
        Guid? AblageGuid { get; set; }
        Guid? AblageFachGuid { get; set; }
        string Lagerfach { get; set; }
    }
}
