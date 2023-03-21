using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class TemplateDTO
    {
        /// <summary>
        /// Eindeutige GUID
        /// </summary>
        public Guid TemplateGuid { get; set; }
        /// <summary>
        /// Titel des Templates
        /// </summary>
        public string Titel { get; set; }
        /// <summary>
        /// Beschreibung
        /// </summary>
        public string Beschreibung { get; set; }
	    /// <summary>
	    /// Legt den Typ eines Templates fest
	    /// </summary>
	    public string Typ { get; set; }
		/// <summary>
		/// Enthält serialisierte Daten für ein Objekt als "Vorlage"
		/// </summary>
		public string JsonDaten { get; set; }
        /// <summary>
        /// ChangedDate (letzte Änderung)
        /// </summary>
        public DateTime ChangedDate { get; set; }
		/// <summary>
		/// Benutzer der das Template erstellt hat
		/// </summary>
		public string Benutzer { get; set; }
	}
}