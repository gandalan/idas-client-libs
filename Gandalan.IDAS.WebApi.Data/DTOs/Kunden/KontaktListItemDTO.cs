using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class KontaktListItemDTO
    {
        public Guid KontaktGuid { get; set; }
        public Guid KontaktMandantGuid { get; set; }
        /// <summary>
        /// Nachname (für Endkunden)
        /// </summary>
        public string Nachname { get; set; }
        /// <summary>
        /// Vorname(n) (für Endkunden)
        /// </summary>
        public string Vorname { get; set; }
        /// <summary>
        /// Firmierung (für jur. Personen)
        /// </summary>
        public string Firmenname { get; set; }
        /// <summary>
        /// Kundennummer (alphanummerisch)
        /// </summary>
        public string KundenNummer { get; set; }
	    /// <summary>
	    /// Strasse
	    /// </summary>
	    public string Strasse { get; set; }
	    /// <summary>
	    /// Land
	    /// </summary>
	    public string Land { get; set; }
	    /// <summary>
	    /// Postleitzahl
	    /// </summary>
	    public string Plz { get; set; }
	    /// <summary>
	    /// Stadt / Ort
	    /// </summary>
	    public string Ort { get; set; }
	    /// <summary>
	    /// Telefon (Zentrale)
	    /// </summary>
	    public string Telefon { get; set; }
	    /// <summary>
	    /// E-Mail (Zentrale)
	    /// </summary>
	    public string Email { get; set; }
		/// <summary>
		/// Endkunde oder Firmenkunde
		/// </summary>
		public bool IstEndkunde { get; set; }
        public bool IstKunde { get; set; }
        public string URL { get; set; }
        public DateTime ChangedDate { get; set; }

        public void copyproperties(KontaktListItemDTO newkontakt)
        {
            newkontakt.KontaktGuid = this.KontaktGuid;
            newkontakt.KontaktMandantGuid = this.KontaktMandantGuid;
            newkontakt.Nachname = this.Nachname;
            newkontakt.Vorname = this.Vorname;
            newkontakt.Firmenname = this.Firmenname;
            newkontakt.KundenNummer = this.KundenNummer;
            newkontakt.IstEndkunde = this.IstEndkunde;
            newkontakt.IstKunde = this.IstKunde;
            newkontakt.URL = this.URL;
            newkontakt.Email = this.Email;

	        newkontakt.Strasse = this.Strasse;
	        newkontakt.Land = this.Land;
	        newkontakt.Plz = this.Plz;
	        newkontakt.Ort = this.Ort;
	        newkontakt.Telefon = this.Telefon;

        }
    }
}
