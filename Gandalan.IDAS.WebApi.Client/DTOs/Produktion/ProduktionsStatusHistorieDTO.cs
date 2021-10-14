using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class ProduktionsStatusHistorieDTO
    {
        public Guid ProduktionsStatusHistorieGuid { get; set; }
        public virtual ProduktionsStatiWerteDTO Status { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime Zeitstempel { get; set; }
        public virtual string Benutzer { get; set; }
    }
}