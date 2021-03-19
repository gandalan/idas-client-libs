namespace Gandalan.IDAS.WebApi.DTO
{
    public enum MaterialBeschaffungsJobStatiDTO
    {
        /// <summary>
        /// Undefinierter Zustand
        /// </summary>
        Unbekannt = 0,
        /// <summary>
        /// Der Job wurde erstellt
        /// </summary>
        Erstellt = 1,
        /// <summary>
        /// Artikel wurde ans Lager übermittelt
        /// </summary>
        Angefragt = 2,
        /// <summary>
        /// Bereitstellung durch Lager erfolgt demnächst
        /// </summary>
        Reserviert = 4,
        /// <summary>
        /// Artikel nicht am Lager, Nachbestellung durch Lager erfolgt
        /// </summary>
        NachschubBestellt = 8,
        /// <summary>
        /// Artikel nicht am Lager, Nachbestellung wird zeitnah aber geliefert
        /// </summary>
        NachschubImZulauf = 16,
        /// <summary>
        /// Artikel sind vollständig für die Produktion vorhanden
        /// </summary>
        Bereitgestellt = 32,
        /// <summary>
        /// Artikelbeschaffung soll abgebrochen werden
        /// </summary>
        Abgebrochen = 64,
        /// <summary>
        /// MaterialbeschaffungsJob wurde durch FolgeJob abgelöst
        /// </summary>
        Abgelöst = 128,
        /// <summary>
        /// Material wurde reklamiert
        /// </summary>
        Reklamiert = 256
    }
}