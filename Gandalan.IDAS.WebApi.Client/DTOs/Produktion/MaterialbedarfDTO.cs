using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class MaterialbedarfDTO : ICloneable
    {
        public Guid MaterialBedarfGuid { get; set; }
        /// <summary>
        /// Eindeutiges Kennzeichen des Items (aus GUID)
        /// </summary>
        public Guid Kennzeichen { get; set; }
        public string InternerName { get; set; }
        //InternerName wird derzeit an vielen Stellen verwendet weshalb wir jetzt die Backup Property hinzufügen welche den echten InternenNamen aus dem Modell beinhaltet
        public string InternerName_Backup { get; set; }
        /// <summary>
        /// Neher-Katalognummer des Artikels
        /// </summary>
        public string KatalogNummer { get; set; }
        /// <summary>
        /// Artikelbezeichnung
        /// </summary>
        public string Bezeichnung { get; set; }
        /// <summary>
        /// Einheit des Artikels (lfm=Laufmeter, Stk=Stück, qm=Quadratmeter)
        /// </summary>
        public string Einheit { get; set; }

        public bool Beipacken { get; set; }

        /// <summary>
        /// Anzahl des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt
        /// sich aus mit Laufmeter!)
        /// </summary>
        public decimal Stueckzahl { get; set; }
        /// <summary>
        /// Laufmeter des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt
        /// sich aus mit Stückzahl!)
        /// </summary>
        public decimal Laufmeter { get; set; }

        /// <summary>
        /// FarbBezeichnung (Bezeichnung der Farbe)
        /// </summary>
        public string FarbBezeichnung { get; set; }
        /// <summary>
        /// FarbeKuerzel (Neher-Kürzel oder Sonderfarbton)
        /// </summary>
        public string FarbKuerzel { get; set; }
        public Guid FarbKuerzelGuid { get; set; }
        /// <summary>
        /// FarbeCode der Farbe
        /// </summary>
        public string FarbCode { get; set; }
        public string FarbeItem { get; set; }
        public Guid FarbItemGuid { get; set; }

        public string OberflaecheBezeichnung { get; set; }
        public Guid OberFlaecheGuid { get; set; }

        /// <summary>
        /// Kennzeichen für Zuschnittartikel
        /// </summary>
        public bool IstZuschnitt { get; set; }
        public float ZuschnittLaenge { get; set; }
        public string ZuschnittWinkel { get; set; }
        public string PositionsAngabe { get; set; }

        public string MaterialBezeichnung { get; set; }
        public bool MaterialBearbeitungSaegen { get; set; }
        public bool MaterialBearbeitungFraesen { get; set; }
        public bool MaterialBearbeitungStanzen { get; set; }
        public bool MaterialBearbeitungBeschichten { get; set; }
        public bool MaterialBearbeitungBohren { get; set; }
        public bool MaterialBearbeitungEloxieren { get; set; }

        public bool AufPackListe { get; set; }
        public string CADKennung { get; set; }
        public string EtikettenSonderS { get; set; }
        public string IndiSonderInfo1 { get; set; }
        public string IndiSonderInfo2 { get; set; }
        public string IndiSonderInfo3 { get; set; }
        public string PIText { get; set; }
        public bool SchraegElement { get; set; }
        public string SonderFormInfo { get; set; }
        public string ZusatzEtikettText { get; set; }
        public bool AufMaterialListe { get; set; }
        public bool NurLieferscheinAnzeige { get; set; }
        public bool FromSonderWunsch { get; set; }

        public bool IstBeschichtbar { get; set; }
        public KatalogArtikelArt KatalogArtikelArt { get; set; }
        public MaterialbedarfStatiDTO AktuellerStatus { get; set; }
        /// <summary>
        /// Kennzeichen, ob das Profil gedreht gesägt wird (z.B. bei PT2/46)
        /// </summary>
        public bool ProfilGedrehtSaegen { get; set; }

        public bool IstSonderfarbe { get; set; }
        public string MaterialPCode { get; set; }
        public string Bemerkung { get; set; }
        public Guid? AVPositionGuid { get; set; }

        public Guid ZielKennzeichen { get; set; }

        public string Lagerfach { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
