namespace Gandalan.IDAS.WebApi.Util;

/// <summary>
/// Keys der i3-App im "settings"-Subobjekt der ApplicationSpecificProperties, gruppiert nach Fachobjekt.
/// Die Werte sind gespeichert und dürfen nicht geändert werden.
/// </summary>
public static class AppPropertyKeys
{
    /// <summary>
    /// Textbausteine je Belegart, am Kontakt gepflegt und in den Vorgang übernommen.
    /// </summary>
    public const string TEXTBAUSTEINE = "Textbausteine";

    public static class Kontakt
    {
        /// <summary>
        /// Bevorzugte Person bzw. Zusatzanschrift eines Kontakts.
        /// </summary>
        public const string FAVORITE = "Favorite";
    }

    public static class Vorgang
    {
        public const string KONTROLLKUERZEL = "Kontrollkuerzel";
        public const string NO_SERIEN_AUTO_ZUORDNUNG = "NoSerienAutoZuordnung";
        public const string BESCHICHTER = "beschichter";
    }

    public static class Beleg
    {
        public const string FREIGABE_AM = "FreigabeAm";
        public const string FREIGEGEBEN_AM = "FreigegebenAm";
        public const string PRODUKTIONSFREIGABE_DATUM = "ProduktionsfreigabeDatum";
        public const string PRODUKTIONSFREIGABE_AUTO = "ProduktionsfreigabeAuto";

        /// <summary>
        /// Druckdatum, das im Ausdruck das Belegdatum ersetzt (Format yyyy-MM-dd).
        /// </summary>
        public const string REPORT_BELEG_DATUM = "ReportBelegDatum";
    }

    public static class BelegPosition
    {
        public const string FESTE_FARB_GRUPPE = "FesteFarbGruppe";
        public const string FESTER_SF_ZUSCHLAG = "FesterSFZuschlag";
        public const string PRICE_MODE = "PriceMode";
        public const string MANUAL_PREIS = "ManualPreis";
        public const string PREIS_AUF_ANFRAGE_KORRIGIERT = "PreisAufAnfrageKorrigiert";
    }
}
