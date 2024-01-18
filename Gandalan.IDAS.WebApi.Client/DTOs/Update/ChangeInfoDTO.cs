using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class ChangeInfoDTO
    {
        public DateTime Kontakte { get; set; }
        public DateTime Vorgaenge { get; set; }
        public DateTime Serien { get; set; }
        public DateTime BelegPositionenAV { get; set; }
        public DateTime Settings { get; set; }
        public DateTime Lagerbestand { get; set; }
        public DateTime BelegPositionen { get; set; }
        public DateTime KalenderKennzeichen { get; set; }
        public DateTime ProduktionsStati { get; set; }
        public DateTime TagInfos { get; set; }
    }
}
