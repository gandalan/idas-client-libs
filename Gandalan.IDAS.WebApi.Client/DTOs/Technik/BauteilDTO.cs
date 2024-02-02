using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class BauteilDTO
    {
        public Guid BauteilGuid { get; set; }

        public virtual Guid BauteilKategorieGuid { get; set; }

        public string Name { get; set; }
        public string Art { get; set; }
        public bool IstRotationsKoerper { get; set; }
        public string ConstructScript { get; set; }
        public string UpdateScript { get; set; }
        public string ValidateScript { get; set; }
        public string EtikettenKuerzel { get; set; }
        public bool IstSichtbar { get; set; }
        public string ArtikelNummer { get; set; }

        public SchnittDTO Schnitt { get; set; }
        public virtual Guid MaterialGuid { get; set; }
        public virtual Guid ZugehoerigerKatalogArtikelGuid { get; set; }

        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
