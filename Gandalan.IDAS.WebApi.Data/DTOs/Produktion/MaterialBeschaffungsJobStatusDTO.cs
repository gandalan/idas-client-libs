namespace Gandalan.IDAS.WebApi.DTO
{
    public enum MaterialBeschaffungsJobStatusDTO
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
        Bereitgestellt = 32
    }
}