using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class ProduzentenFarbGruppeDTO
    {
        public ProduzentenFarbGruppeDTO()
        {
            Farben = new ObservableCollection<Guid>();
            Oberflaechen = new ObservableCollection<Guid>();
        }

        public Guid ProduzentenFarbGruppeGuid { get; set; }
        public string Name { get; set; }
        public IList<Guid> Oberflaechen { get; set; }
        public IList<Guid> Farben { get; set; }
        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
