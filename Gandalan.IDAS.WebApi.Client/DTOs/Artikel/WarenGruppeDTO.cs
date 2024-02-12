using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class WarenGruppeDTO
    {
        public Guid WarenGruppeGuid { get; set; }
        public int Nummer { get; set; }
        public string Bezeichnung { get; set; }
        public bool IstEKPWarengruppe { get; set; }
        public IList<KatalogArtikelDTO> Artikel { get; set; }
        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
        public string FrontendLogik { get; set; }

        public WarenGruppeDTO()
        {
            Artikel = new ObservableCollection<KatalogArtikelDTO>();
        }
    }
}
