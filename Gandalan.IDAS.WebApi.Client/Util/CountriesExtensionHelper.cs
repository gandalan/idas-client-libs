using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class CountriesExtensionHelper
    {
        #region Country names

        private static readonly string[] _euCountryCodes =
        {
            // keep DE + AT in front for better performance with most of requests
            "Deutschland", "DE", "D",
            "Österreich", "AT", "A",

            "Belgien", "België", "Belgique", "Belgien", "BE",
            "Bulgarien", "България", "BG",
            "Dänemark", "Danmark", "DK",
            "Estland", "Eesti", "EE",
            "Finnland", "Suomi", "Finland", "FI",
            "Frankreich", "France", "FR", "F",
            "Griechenland", "Ελλάδα", "Ελλάς", "GR",
            "Irland", "Éire", "Ireland", "IE",
            "Italien", "Italia", "IT",
            "Kroatien", "Hrvatska", "HR",
            "Lettland", "Latvija", "LV",
            "Litauen", "Lietuva", "LT",
            "Luxemburg", "Lëtzebuerg", "Luxemburg", "Luxembourg", "LU", "L",
            "Malta", "Malta", "MT",
            "Niederlande", "Nederland", "NL",
            "Polen", "Polska", "PL",
            "Portugal", "Portugal", "PT",
            "Rumänien", "România", "RO",
            "Schweden", "Sverige", "SE",
            "Slowakei", "Slovensko", "SK",
            "Slowenien", "Slovenija", "SI",
            "Spanien", "España", "ES",
            "Tschechien", "Česko", "CZ",
            "Ungarn", "Magyarország", "HU",
            "Zypern", "Κύπρος", "Kıbrıs", "CY"
        };

        #endregion

        public static bool IsEUCountry(this string land)
        {
            return string.IsNullOrEmpty(land) ||
                   _euCountryCodes.Any(t => land.Equals(t, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsInland(this string land, IEnumerable<string> inlandsLaender)
        {
            return string.IsNullOrEmpty(land) ||
                   inlandsLaender.Any(x => land.Equals(x, StringComparison.OrdinalIgnoreCase));
        }
    }
}
