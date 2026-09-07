using System.Collections.Generic;
using System.Linq;
using Gandalan.IDAS.WebApi.DTO;

namespace System;
public static class BelegPositionDTOExtension
{
    /// <summary>
    /// Prüft, ob eine Belegposition mit einer anderen Version der Aufpreise oder der Preisliste gerechnet wurde,
    /// als heute gültig ist. Maßgeblich ist die Version, die zum Erfassungsdatum der Position galt (dieselbe Auswahl
    /// wie beim Laden der Listen über die Resource-Registry), verglichen mit der heute gültigen Version.
    /// Wenn ja, könnte dies bedeuten, dass die Position mit veralteten Preisen erfasst wurde und möglicherweise aktualisiert werden muss.
    /// Versionen, deren Gültigkeit erst in der Zukunft beginnt, gelten nicht als "heute gültig": Aufpreis- und
    /// Preislisten werden bewusst im Voraus angelegt und sollen bis zu ihrem Gültigkeitsbeginn keine Warnung auslösen.
    /// Liegt das Erfassungsdatum in der Zukunft und rechnet die Position dadurch bereits mit einer noch nicht gültigen
    /// Version, wird ebenfalls gewarnt.
    /// </summary>
    /// <returns>True, wenn die zum Erfassungsdatum gültige Version der Aufpreise oder Preisliste von der heute gültigen abweicht, sonst False.</returns>
    public static bool CheckPreisListeZuErfassungsdatum(this BelegPositionDTO belegPosition, ResourceRegistry registry)
    {
        if (belegPosition is null || registry?.Ressourcen is null)
            return false;

        if (belegPosition.Variante is not { Length: >= 3 })
            return false;

        var produktFamilieAufpreise = $"{belegPosition.Variante[..3].ToUpperInvariant()}Aufpreise";
        var preislistenName = belegPosition.Daten?.FirstOrDefault(d => d.KonfigName == "Konfig.PreislistenName")?.Wert;

        return CheckResourceCategoryForDifferentVersion(registry.Ressourcen, "aufpreise", produktFamilieAufpreise, belegPosition.ErfassungsDatum)
            || CheckResourceCategoryForDifferentVersion(registry.Ressourcen, "aufpreise", "GewebeAufpreise", belegPosition.ErfassungsDatum)
            || CheckResourceCategoryForDifferentVersion(registry.Ressourcen, "preise", preislistenName, belegPosition.ErfassungsDatum);
    }

    private static bool CheckResourceCategoryForDifferentVersion(
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

        if (category is null || !category.TryGetValue(resourceName, out var versionen) || versionen is null)
            return false;

        var zumErfassungsdatum = FindMatchingVersion(versionen, erfassungsDatum);
        var heute = FindMatchingVersion(versionen, DateTime.UtcNow);

        return !string.Equals(zumErfassungsdatum?.Pfad, heute?.Pfad, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Jüngste Version, die zum Stichtag bereits gültig ist. Entspricht der Auswahl des ResourceResolvers beim Laden der Listen.
    /// </summary>
    private static ResourceEntry FindMatchingVersion(List<ResourceEntry> versionen, DateTime stichtag)
    {
        return versionen
            .Where(v => v.GueltigAb <= stichtag)
            .OrderByDescending(v => v.GueltigAb)
            .FirstOrDefault();
    }
}
