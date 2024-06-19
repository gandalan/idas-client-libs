using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Util;

public class VarianteComparerByNeherName : IComparer<VarianteDTO>
{
    private static readonly Regex _variantenNameRex = new(@"(?:[a-zA-Z]{1,3}|\d{1,3}|\.[a-zA-Z]{1,3})\s*", RegexOptions.CultureInvariant | RegexOptions.Compiled);

    public int Compare(VarianteDTO x, VarianteDTO y)
    {
        var partsX = _variantenNameRex.Matches(x.Name.ToLower()).Cast<Match>().Select(m => m.Value).ToArray();
        var partsY = _variantenNameRex.Matches(y.Name.ToLower()).Cast<Match>().Select(m => m.Value).ToArray();

        var wertA = GetFamilienWert(partsX[0]);
        var wertB = GetFamilienWert(partsY[0]);
        if (wertA != wertB)
        {
            return wertA - wertB;
        }

        if (partsX.Length > 1)
        {
            wertA += GetGruppenWert(partsX[1]);
        }

        if (partsY.Length > 1)
        {
            wertB += GetGruppenWert(partsY[1]);
        }

        if (wertA != wertB)
        {
            return wertA - wertB;
        }

        if (partsX.Length > 2)
        {
            wertA += GetProduktWert(partsX[2]);
        }

        if (partsY.Length > 2)
        {
            wertB += GetProduktWert(partsY[2]);
        }

        if (wertA != wertB)
        {
            return wertA - wertB;
        }

        if (partsX.Length > 3)
        {
            wertA += GetAbart(partsX[3]);
        }

        if (partsY.Length > 3)
        {
            wertB += GetAbart(partsY[3]);
        }

        return wertA - wertB;
    }

    private static int GetAbart(string p)
    {
        return !string.IsNullOrEmpty(p) ? 50 : 0;
    }

    private static int GetProduktWert(string p)
    {
        return int.TryParse(p, out var result) ? result : 99;
    }

    private static int GetGruppenWert(string p)
    {
        return int.TryParse(p, out var result) ? result * 100 : 999;
    }

    private static int GetFamilienWert(string p)
    {
        int result;
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