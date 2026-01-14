using Gandalan.IDAS.WebApi.Client.Contracts;

namespace System;

public static class IWithGueltigkeitsZeitraumExtensions
{
    extension(IWithGueltigkeitsZeitraum gueltig)
    {
        public bool IstGueltig(DateTime? referenceDate = null) =>
            gueltig switch
            {
                null => false,
                { GueltigAb: null, GueltigBis: null } => true,
                _ => isWithinValidityPeriod(gueltig, (referenceDate ?? DateTime.UtcNow).Date)
            };
    }

    private static bool isWithinValidityPeriod(IWithGueltigkeitsZeitraum gueltig, DateTime refDate) =>
        (gueltig.GueltigAb is null || gueltig.GueltigAb.Value.Date <= refDate)
        && (gueltig.GueltigBis is null || gueltig.GueltigBis.Value.Date >= refDate);
}
