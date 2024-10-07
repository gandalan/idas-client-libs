using Gandalan.IDAS.WebApi.Client.Contracts;

namespace System;

public static class Gueltigkeit
{
    public static bool IstGueltig(this IWithGueltigkeitsZeitraum gueltig, DateTime? referenceDate = null)
    {
        if (gueltig == null)
        {
            return false;
        }

        if (gueltig.GueltigAb == null && gueltig.GueltigBis == null)
        {
            return true;
        }

        referenceDate ??= DateTime.UtcNow;

        if (gueltig.GueltigAb != null && gueltig.GueltigAb.Value.Date < referenceDate.Value.Date)
        {
            return false;
        }

        if (gueltig.GueltigBis != null && gueltig.GueltigBis.Value.Date > referenceDate.Value.Date)
        {
            return false;
        }

        return true;
    }
}
