using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    public partial class KomponenteDTO
    {
        public Guid KomponenteGuid { get; set; }
        public virtual Guid BauteilGuid { get; set; }

        public Guid GehoertZuKomponenteGuid { get; set; }
        public Guid KomponenteArtGuid { get; set; }
        public Guid KomponenteKategorieGuid { get; set; }
        public string Name { get; set; }
        public string AnzeigeName { get; set; }
        public string Bild { get; set; }
        public bool Bestellbar { get; set; }
        public bool IstSichtbar { get; set; }
        public string AenderungsInfoWeiterleitungen { get; set; }
        public List<Guid> gehoerenZuKomponente { get; set; }
        public string ConstructScript { get; set; }
        public string UpdateScript { get; set; }
        public string ValidateScript { get; set; }
        public string ReconstructScript { get; set; }
        public string BearbeitungenScript { get; set; }
        public string FeatureErkennungScript { get; set; }

        public Guid ZugehoerigerKatalogArtikelGuid { get; set; }

        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }

        public List<KomponenteVariableDTO> Variablen { get; set; }
        public List<KomponenteVerknuepfungDTO> Verknuepfungen { get; set; }
    }
}