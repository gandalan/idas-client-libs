using System.Collections.Generic;
using System.Linq;
using Gandalan.IDAS.WebApi.DTO;

namespace System;
public static class BelegPositionDTOExtension
{
    /// <summary>
    /// Prüft, ob zu einer Belegposition eine neuere Version der Aufpreise oder der Preisliste existiert, die nach dem Erfassungsdatum der Position gültig wird.
    /// Wenn ja, könnte dies bedeuten, dass die Position mit veralteten Preisen erfasst wurde und möglicherweise aktualisiert werden muss.
    /// </summary>
    /// <returns>True, wenn eine neuere Version der Aufpreise oder Preisliste existiert, sonst False.</returns>
    public static bool CheckPreisListeZuErfassungsdatum(this BelegPositionDTO belegPosition, ResourceRegistry registry)
    {
        if (belegPosition is null || registry?.Ressourcen is null)
            return false;

        if (belegPosition.Variante is not { Length: >= 3 })
            return false;

        var produktFamilieAufpreise = $"{belegPosition.Variante[..3].ToUpperInvariant()}Aufpreise";
        var preislistenName = belegPosition.Daten?.FirstOrDefault(d => d.KonfigName == "Konfig.PreislistenName")?.Wert;

        return CheckResourceCategoryForNewerVersion(registry.Ressourcen, "aufpreise", produktFamilieAufpreise, belegPosition.ErfassungsDatum)
            || CheckResourceCategoryForNewerVersion(registry.Ressourcen, "aufpreise", "GewebeAufpreise", belegPosition.ErfassungsDatum)
            || CheckResourceCategoryForNewerVersion(registry.Ressourcen, "preise", preislistenName, belegPosition.ErfassungsDatum);
    }

    private static bool CheckResourceCategoryForNewerVersion(
        Dictionary<string, Dictionary<string, List<ResourceEntry>>> ressourcen,
        string categoryName,
        string resourceName,
        DateTime erfassungsDatum)
    {
        if (string.IsNullOrEmpty(resourceName))
            return false;

        var category = ressourcen
            .FirstOrDefault(kvp => kvp.Key.Equals(categoryName, StringComparison.OrdinalIgnoreCase))
            .Value;

        return category is not null
            && category.TryGetValue(resourceName, out var versionen)
            && versionen?.Any(v => v.GueltigAb > erfassungsDatum) == true;
    }
}
