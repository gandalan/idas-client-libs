using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.DTO.Gesamtbedarf
{
    [Flags]
    public enum ZusammenfassungsOptionen
    {
        Keine = 0,
        Lieferdatum = 1,
        Serienzuordnung = 2,
        Artikelnummer_Frabe_Oberflaeche = 4,
        Vorgang = 8
    }

    [Flags]
    public enum SchnittoptimierungsOptionen
    {
        Keine = 0,
        Lieferdatum = 1,
        Serie = 2,
        Frabe_Oberflaeche = 4,
    }
}
