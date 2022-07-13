using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts.AV
{
    public class SerienKapazitaetInfo
    {
        public Guid SerieGuid { get; set; }
        public decimal GesamtKapazitaet { get; set; }
        public decimal BenoetigteKapazitaet { get; set; }
    }
}
