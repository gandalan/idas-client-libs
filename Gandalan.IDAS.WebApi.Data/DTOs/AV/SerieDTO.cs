using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class SerieDTO
    {
        public Guid SerieGuid { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; } = new DateTime(2000, 1, 1);
        public DateTime Ende { get; set; } = new DateTime(2099, 12, 31);
        public bool StaendigeSerie { get; set; }
        public bool ProduktionFreigegeben { get; set; }
        public bool UnterlagenGedruckt { get; set; }
        public IList<Guid> AVBelegPositionen { get; set; } = new List<Guid>();
        public decimal Kapazitaet { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
