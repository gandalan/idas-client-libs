using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class KomponenteVerknuepfungDTO
    {
        public Guid KomponenteVerknuepfungGuid { get; set; }
        public Guid QuellKomponenteGuid { get; set; }
        public Guid ZielKomponenteGuid { get; set; }
        public string Name { get; set; }
        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}