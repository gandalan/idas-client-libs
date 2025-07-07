using System.Text;
using Gandalan.IDAS.WebApi.Client.Contracts.AV;

namespace Gandalan.IDAS.WebApi.DTO;

public static class FarbExtensions
{
    public static string GetProduktionsFarbText(this MaterialbedarfDTO material, FarbtextOption? farbtextOption = null)
    {
        var farbText = material.FarbKuerzel;
        if (string.IsNullOrEmpty(farbText))
        {
            return string.Empty;
        }

        // Standardfarbe
        if (!farbText.StartsWith("SF"))
        {
            if (farbtextOption == FarbtextOption.Volltext)
            {
                farbText = getProduktionsFarbText(farbText, farbZusatzText: null, material.FarbeItem, material.FarbCode, material.FarbBezeichnung, material.OberflaecheBezeichnung, material.IstBeschichtbar);
            }
        }
        // Sonderfarben / Trendfarben ("SF" + FarbZusatzText)
        else if (farbText.StartsWith("SF"))
        {
            farbText = getProduktionsFarbText(farbText, material.FarbZusatzText, material.FarbeItem, material.FarbCode, material.FarbBezeichnung, material.OberflaecheBezeichnung, material.IstBeschichtbar);
        }

        if (!string.IsNullOrWhiteSpace(material.PulverCode))
        {
            farbText += $" {material.PulverCode}";
        }

        return farbText;
    }

    private static string getProduktionsFarbText(string farbKuerzel, string farbZusatzText, string farbItem, string farbCode, string farbBezeichnung, string oberflaecheBezeichnung, bool longText)
    {
        var sb = new StringBuilder();
        if (!string.IsNullOrEmpty(farbKuerzel))
        {
            sb.Append(farbKuerzel);
        }

        // For some colors (e.g. W3: "W3 matt") Ibos1 returns the farbKuerzel in the farbBezeichnung, so we do not add the farbZusatzText, which contains the farbKuerzel, too.
        // if shortText, we just add it
        if (!string.IsNullOrEmpty(farbZusatzText) && (!farbBezeichnung.Contains(farbZusatzText) || !longText))
        {
            sb.Append($" {farbZusatzText}");
        }

        // For some (user specific standard) colors Ibos1/2 swallow color kuerzel. So we add it here, if not already present
        if (farbItem != null && farbItem.Length >= 2 && farbItem.Length <= 4 && !sb.ToString().Contains(farbItem) && !farbBezeichnung.Contains(farbItem))
        {
            sb.Append($" {farbItem}");
        }

        if (!longText)
        {
            return sb.ToString();
        }

        if (!string.IsNullOrEmpty(farbCode))
        {
            sb.Append($" {farbCode}");
        }

        // For custom Handeingaben: FarbBezeichnung == FarbCode == FarbItem, so do not add twice
        if (!string.IsNullOrEmpty(farbBezeichnung) && !sb.ToString().Contains(farbBezeichnung))
        {
            sb.Append($" {farbBezeichnung}");
        }

        if (!string.IsNullOrEmpty(oberflaecheBezeichnung) && oberflaecheBezeichnung != "Standard" && !sb.ToString().Contains(oberflaecheBezeichnung))
        {
            sb.Append($" {oberflaecheBezeichnung}");
        }

        return sb.ToString();
    }
}
