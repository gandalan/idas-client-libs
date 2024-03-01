using System;
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
            farbText = GetProduktionsFarbText(farbText, farbZusatzText: null, material.FarbCode, material.FarbBezeichnung, material.OberflaecheBezeichnung, material.IstBeschichtbar);
        }
        // Trendfarbe ("SF" + FarbZusatzText)
        else if (farbText.StartsWith("SF") && !string.IsNullOrEmpty(material.FarbZusatzText))
        {
            farbText = GetProduktionsFarbText(farbText, material.FarbZusatzText, material.FarbCode, material.FarbBezeichnung, material.OberflaecheBezeichnung, material.IstBeschichtbar);
        }
        // Sonderfarbe
        else if (farbText.StartsWith("SF") && !string.IsNullOrEmpty(material.FarbCode))
        {
            // Handeingabe
            if (material.FarbItemGuid == Guid.Empty)
            {
                farbText = GetProduktionsFarbText(farbText, farbZusatzText: null, farbCode: material.FarbCode, farbBezeichnung: null, oberflaecheBezeichnung: null, istBeschichtbar: true);
            }
            // Sonderfarbe aus Liste
            else
            {
                farbText = GetProduktionsFarbText(farbText, material.FarbZusatzText, material.FarbCode, material.FarbBezeichnung, material.OberflaecheBezeichnung, material.IstBeschichtbar);
            }
        }

        return farbText;
    }

    private static string GetProduktionsFarbText(string farbKuerzel, string farbZusatzText, string farbCode, string farbBezeichnung, string oberflaecheBezeichnung, bool istBeschichtbar)
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

        if (!istBeschichtbar) // Wenn nicht beschichtbar, einfach Kürzel anzeigen.
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
