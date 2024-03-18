using System.Text;

namespace Gandalan.IDAS.WebApi.DTO;

public static class FarbExtensions
{
    public static string GetProduktionsFarbText(this MaterialbedarfDTO material)
    {
        var farbText = material.FarbKuerzel;
        if (string.IsNullOrEmpty(farbText))
        {
            return string.Empty;
        }

        // Standardfarbe
        if (!farbText.StartsWith("SF"))
        {
            // Stand 05.03.2024: Für Standardfarben wird immer das Kürzel angezeigt
        }
        // Sonderfarben / Trendfarben ("SF" + FarbZusatzText)
        else if (farbText.StartsWith("SF"))
        {
            farbText = GetProduktionsFarbText(farbText, material.FarbZusatzText, material.FarbeItem, material.FarbCode, material.FarbBezeichnung, material.OberflaecheBezeichnung, material.IstBeschichtbar);
        }

        return farbText;
    }

    private static string GetProduktionsFarbText(string farbKuerzel, string farbZusatzText, string farbItem, string farbCode, string farbBezeichnung, string oberflaecheBezeichnung, bool longText)
    {
        var sb = new StringBuilder();
        if (!string.IsNullOrEmpty(farbKuerzel))
        {
            sb.Append(farbKuerzel);
        }

        if (!string.IsNullOrEmpty(farbZusatzText))
        {
            sb.Append(" " + farbZusatzText);
        }

        // For some (user specific standard) colors Ibos1/2 swallow color kuerzel. So we add it here, if not already present
        if (farbItem != null && farbItem.Length >= 2 && farbItem.Length <= 4 && !sb.ToString().Contains(farbItem) && !farbBezeichnung.Contains(farbItem))
        {
            sb.Append(" " + farbItem);
        }

        if (!longText)
        {
            return sb.ToString();
        }

        if (!string.IsNullOrEmpty(farbCode))
        {
            sb.Append(" " + farbCode);
        }

        if (!string.IsNullOrEmpty(farbBezeichnung))
        {
            sb.Append(" " + farbBezeichnung);
        }

        if (!string.IsNullOrEmpty(oberflaecheBezeichnung) && oberflaecheBezeichnung != "Standard")
        {
            sb.Append(" " + oberflaecheBezeichnung);
        }

        return sb.ToString();
    }
}
