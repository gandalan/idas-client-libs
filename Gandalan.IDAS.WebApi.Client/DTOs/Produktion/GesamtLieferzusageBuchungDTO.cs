using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class GesamtLieferzusageBuchungDTO : ICloneable
    {
        public Guid GesamtLieferzusageBuchungGuid { get; set; }
        public Guid MandantGuid { get; set; }
        public Guid GesamtMaterialbedarfGuid { get; set; }
        public decimal Stueckzahl { get; set; }
        public decimal Laufmeter { get; set; }
        public DateTime Buchungsdatum { get; set; }

        public object Clone()
        {
            return new GesamtLieferzusageBuchungDTO
            {
                GesamtLieferzusageBuchungGuid = GesamtLieferzusageBuchungGuid,
                MandantGuid = MandantGuid,
                GesamtMaterialbedarfGuid = GesamtMaterialbedarfGuid,
                Stueckzahl = Stueckzahl,
                Laufmeter = Laufmeter,
                Buchungsdatum = Buchungsdatum
            };
        }
    }
}

