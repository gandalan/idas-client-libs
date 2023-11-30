using Gandalan.IDAS.WebApi.Client.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System;
public static class Gueltigkeit
{
    public static bool IstGueltig(this IWithGueltigkeitsZeitraum gueltig, DateTime? referenceDate = null)
    {
        if (gueltig == null)
            return false;

        if (gueltig.GueltigAb == null && gueltig.GueltigBis == null)
            return true;

        if (referenceDate == null)
            referenceDate = DateTime.UtcNow;

        if (gueltig.GueltigAb != null && gueltig.GueltigBis > referenceDate)
            return false;

        if (gueltig.GueltigBis != null && gueltig.GueltigBis < referenceDate)
            return false;

        return true;
    }
}
