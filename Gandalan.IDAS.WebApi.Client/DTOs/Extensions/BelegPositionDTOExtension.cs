using System.Collections.Generic;
using System.Linq;
using Gandalan.IDAS.WebApi.DTO;

namespace System;
public static class BelegPositionDTOExtension
{
    /// <summary>
    /// Prüft, ob zu einer Belegposition eine Version der Aufpreise oder der Preisliste existiert, die nach dem
    /// Erfassungsdatum der Position gültig geworden und inzwischen in Kraft ist.
    /// Wenn ja, könnte dies bedeuten, dass die Position mit veralteten Preisen erfasst wurde und möglicherweise aktualisiert werden muss.
    /// Versionen, deren Gültigkeit erst in der Zukunft beginnt, zählen nicht: Aufpreis- und Preislisten werden
    /// bewusst im Voraus angelegt und sollen bis zu ihrem Gültigkeitsbeginn keine Warnung auslösen.
    /// </summary>
    /// <returns>True, wenn eine inzwischen gültige, neuere Version der Aufpreise oder Preisliste existiert, sonst False.</returns>
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
            && versionen?.Any(v => v.GueltigAb > erfassungsDatum && v.GueltigAb <= DateTime.UtcNow) == true;
    }
}
