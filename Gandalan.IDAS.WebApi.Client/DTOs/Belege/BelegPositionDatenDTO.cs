using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class BelegPositionDatenDTO
    {
        public string UnterkomponenteName { get; set; }
        public string KonfigName { get; set; }
        public string Wert { get; set; }
        public string DatenTyp { get; set; }
        public Guid BelegPositionDatenGuid { get; set; }

        public BelegPositionDatenDTO()
        {
            BelegPositionDatenGuid = Guid.NewGuid();
        }

        public override string ToString()
        {
            return UnterkomponenteName + "/" + KonfigName + "=" + Wert;
        }
    }
}
