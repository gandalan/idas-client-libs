using System;

namespace Gandalan.IDAS.Contracts.Belege
{
    [Obsolete("Please use BelegArt from Gandalan.IDAS.WebApi.Data.DTOs.Belege namespace!")]
    public enum BelegArt
    {
        Unbekannt = 0,
        Angebot = 1,
        AB = 2,
        Rechnung = 3,
        Lieferschein = 4,
        Bestellschein = 5,
        ProduktionsAuftrag = 6,
        ZuschnittAuftrag = 7,
        VersandAuftrag = 8,
        MaterialBestellschein = 9,
        ReklamationsBestellschein = 10,
        Gutschrift = 11,
        Storno = 12,
    }

    [Obsolete("Please use BelegWorkflow from Gandalan.IDAS.WebApi.Data.DTOs.Belege namespace!")]
    public struct BelegWorkflow
    {
        public static WebApi.Data.DTOs.Belege.BelegArt[] Steps = {
            WebApi.Data.DTOs.Belege.BelegArt.Angebot,
            WebApi.Data.DTOs.Belege.BelegArt.Bestellschein,
            WebApi.Data.DTOs.Belege.BelegArt.AB,
            WebApi.Data.DTOs.Belege.BelegArt.ProduktionsAuftrag,
            WebApi.Data.DTOs.Belege.BelegArt.ZuschnittAuftrag,
            WebApi.Data.DTOs.Belege.BelegArt.VersandAuftrag,
            WebApi.Data.DTOs.Belege.BelegArt.Lieferschein,
            WebApi.Data.DTOs.Belege.BelegArt.ReklamationsBestellschein,
            WebApi.Data.DTOs.Belege.BelegArt.Rechnung,
        };

        /// <summary>
        /// Prüft, ob neueBelegArt logisch hinter belegArt liegt
        /// </summary>
        /// <param name="neueBelegArt"></param>
        /// <param name="belegArt"></param>
        /// <returns>true/false</returns>
        public static bool IsBehind(WebApi.Data.DTOs.Belege.BelegArt neueBelegArt, WebApi.Data.DTOs.Belege.BelegArt belegArt)
        {
            return Array.IndexOf(Steps, neueBelegArt) > Array.IndexOf(Steps, belegArt);
        }

        /// <summary>
        /// Prüft, ob neueBelegArt logisch vor belegArt liegt
        /// </summary>
        /// <param name="neueBelegArt"></param>
        /// <param name="belegArt"></param>
        /// <returns>true/false</returns>
        public static bool IsBefore(WebApi.Data.DTOs.Belege.BelegArt neueBelegArt, WebApi.Data.DTOs.Belege.BelegArt belegArt)
        {
            return Array.IndexOf(Steps, neueBelegArt) < Array.IndexOf(Steps, belegArt);
        }
    }
}
