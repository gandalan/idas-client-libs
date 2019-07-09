using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class MaterialBeschaffungsJobHistorieDTO
    {
        public Guid MaterialBeschaffungsJobHistorieGuid { get; set; }
        public virtual MaterialBeschaffungsJobStatiDTO Status { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime Zeitstempel { get; set; }
        public virtual string Benutzer { get; set; }
    }
}