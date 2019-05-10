using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO.DTOs.Reports
{
    public enum ReportDatenTypDTO
    {
        Unbekannt = 0,
        Beleg = 1,
        Etiketten = 2,
        Statistik = 4,
        KundenListe = 8,
        Kunden = 16
    }
}
