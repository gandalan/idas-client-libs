using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Gandalan.IDAS.WebApi.Util
{
    public class VarianteComparerByNeherName : IComparer<VarianteDTO>
    {
        private static Regex variantenNameRex = new Regex(@"(?:[a-zA-Z]{1,3}|\d{1,3}|\.[a-zA-Z]{1,3})\s*", RegexOptions.CultureInvariant | RegexOptions.Compiled);

        public int Compare(VarianteDTO x, VarianteDTO y)
        {
            string[] partsX = variantenNameRex.Matches(x.Name.ToLower()).Cast<Match>().Select(m => m.Value).ToArray();
            string[] partsY = variantenNameRex.Matches(y.Name.ToLower()).Cast<Match>().Select(m => m.Value).ToArray();

            int wertA = getFamilienWert(partsX[0]);
            int wertB = getFamilienWert(partsY[0]);
            if (wertA != wertB) return wertA - wertB;

            if (partsX.Length > 1) wertA += getGruppenWert(partsX[1]);
            if (partsY.Length > 1) wertB += getGruppenWert(partsY[1]);
            if (wertA != wertB) return wertA - wertB;

            if (partsX.Length > 2) wertA += getProduktWert(partsX[2]);
            if (partsY.Length > 2) wertB += getProduktWert(partsY[2]);
            if (wertA != wertB) return wertA - wertB;

            if (partsX.Length > 3) wertA += getAbart(partsX[3]);
            if (partsY.Length > 3) wertB += getAbart(partsY[3]);
            return wertA - wertB;
        }

        private int getAbart(string p)
        {
            return !string.IsNullOrEmpty(p) ? 50 : 0;
        }

        private int getProduktWert(string p)
        {
            return int.TryParse(p, out int result) ? result : 99;
        }

        private int getGruppenWert(string p)
        {
            return int.TryParse(p, out int result) ? result * 100 : 999;
        }

        private int getFamilienWert(string p)
        {
            int result = 0;
            switch (p.ToLower().Trim())
            {
                case "sp": result = 1000; break;
                case "pf": result = 2000; break;
                case "df": result = 3000; break;
                case "pt": result = 4000; break;
                case "dt": result = 5000; break;
                case "ro": result = 6000; break;
                case "sd": result = 7000; break;
                case "er": result = 8000; break;
                case "pl": result = 9000; break;
                case "st": result = 10000; break;
                case "li": result = 11000; break;
                case "te": result = 12000; break;
                case "zr": result = 13000; break;
                case "rf": result = 14000; break;
                case "rt": result = 15000; break;
                case "rk": result = 16000; break;
                default:
                    result = 17000;
                    break;
            }
            return result;
        }
    }
}
