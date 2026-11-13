using System.Collections.Generic;
using System.Linq;
using Gandalan.IDAS.WebApi.Client.Contracts;

namespace System;

public static class IWithGueltigkeitsZeitraumExtensions
{
    public static bool IstGueltig(this IWithGueltigkeitsZeitraum gueltig, DateTime? referenceDate = null) =>
        gueltig switch
        {
            null => false,
            { GueltigAb: null, GueltigBis: null } => true,
            _ => isWithinValidityPeriod(gueltig, (referenceDate ?? DateTime.UtcNow).Date)
        };

    public static IEnumerable<T> WhereIstGueltig<T>(this IEnumerable<T> list, DateTime? referenceDate = null)
        where T : IWithGueltigkeitsZeitraum
        => list.Where(i => i.IstGueltig(referenceDate));

    private static bool isWithinValidityPeriod(IWithGueltigkeitsZeitraum gueltig, DateTime refDate) =>
        (gueltig.GueltigAb is null || gueltig.GueltigAb.Value.Date <= refDate)
        && (gueltig.GueltigBis is null || gueltig.GueltigBis.Value.Date >= refDate);
}