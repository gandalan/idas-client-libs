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
        if (belegPosition.Variante is not { Length: >= 3 })
            return false;

        var produktFamilieAufpreise = $"{belegPosition.Variante[..3].ToUpperInvariant()}Aufpreise";
        var preislistenName = belegPosition.Daten.FirstOrDefault(d => d.KonfigName == "Konfig.PreislistenName")?.Wert;

        return CheckResourceCategoryForNewerVersion(registry, "aufpreise", produktFamilieAufpreise, belegPosition)
            || CheckResourceCategoryForNewerVersion(registry, "aufpreise", "GewebeAufpreise", belegPosition)
            || CheckResourceCategoryForNewerVersion(registry, "preise", preislistenName, belegPosition);
    }

    private static bool CheckResourceCategoryForNewerVersion(ResourceRegistry registry, string categoryName, string resourceName, BelegPositionDTO position)
    {
        var category = registry.Ressourcen
            .FirstOrDefault(kvp => kvp.Key.Equals(categoryName, StringComparison.OrdinalIgnoreCase))
            .Value;

        return category is not null
            && category.TryGetValue(resourceName, out var versionen)
            && versionen?.Any(v => v.GueltigAb > position.ErfassungsDatum) == true;
    }
}
