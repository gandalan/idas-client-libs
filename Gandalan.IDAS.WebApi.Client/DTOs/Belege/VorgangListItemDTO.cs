using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.Util;

namespace Gandalan.IDAS.WebApi.DTO
{

    public class VorgangListItemDTO : IDTOWithApplicationSpecificProperties
    {
        /// <summary>
        /// Eindeutige GUID
        /// </summary>
        public Guid VorgangGuid { get; set; }
        /// <summary>
        /// Sichtbare Vorgangsnummer/zur Info für Kunden usw.
        /// </summary>
        public long VorgangsNummer { get; set; }
        /// <summary>
        /// Vorgangsnummer vom Originalbeleg
        /// </summary>
        public long? OriginalVorgangsNummer { get; set; }
        /// <summary>
        /// Erstelldatum des Vorgangs
        /// </summary>
        public DateTime ErstellDatum { get; set; }
        /// <summary>
        /// Datum der letzten Änderung
        /// </summary>
        public DateTime AenderungsDatum { get; set; }
        /// <summary>
        /// Art des aktuellsten Belegs
        /// </summary>
        public string AktuelleBelegArt { get; set; }
        /// <summary>
        /// Eingegebene Kommission des Händlers
        /// </summary>
        public string Kommission { get; set; }
        /// <summary>
        /// Eingegebene Notitzen zum Vorgang vom Produzenten
        /// </summary>
        public string VorgangsNotitz { get; set; }
        /// <summary>
        /// Aktuelle Belegnummer
        /// </summary>        
        public string AktuelleBelegNummer { get; set; }
        /// <summary>
        /// Die GUID des aktuellen Beleges.
        /// </summary>
        public Guid AktuelleBelegGuid { get; set; }
        /// <summary>
        /// Kundennummer des Kunden
        /// </summary>
        public string KundenNummer { get; set; }
        /// <summary>
        /// Name des Kunden für Anzeige
        /// </summary>
        public string Kundenname { get; set; }
        /// <summary>
        /// Guide des Kunden für Filter
        /// </summary>
        public Guid KundeGuid { get; set; }
        /// <summary>
        /// Adresse des detaillierten Vorgangs-Objektes
        /// </summary>
        public string URL { get; set; }
        public Dictionary<string, PropertyValueCollection> ApplicationSpecificProperties { get; set; }
        public string Status { get; set; }
        public int AnzahlNachrichten { get; set; }
        public bool IsArchiv { get; set; }

        public bool HatFehlerhaftenBeleg { get; set; }
        public bool PreisAufAnfrage { get; set; }
        public bool KundeFehlt => 
            KundeGuid.Equals(Guid.Empty) 
            || string.IsNullOrEmpty(KundenNummer) || KundenNummer.Equals("<nicht zugeordnet>");

        public string TextStatus { get; set; }
        // Email des Besitzer
        public string Besitzer { get; set; }
        // Falls Benutzer null und 1. Beleg ist Bestellschein -> Bestellfix -> Besitzer aus OriginalVorgangGuid aus Vorgang
        public string Besteller { get; set; }
        // Der Ansprechpartner vom letzten Beleg des Vorgangs
        public string Bearbeiter { get; set; }
        public string ExterneReferenznummer { get; set; }
        public Guid? ExterneMandantenGuid { get; set; }
        public string ExternerFirmenname { get; set; }

        public Guid MandantGuid { get; set; }
    }
}
