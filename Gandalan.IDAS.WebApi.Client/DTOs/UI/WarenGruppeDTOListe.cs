using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class WarenGruppeDTOListe : ObservableCollection<WarenGruppeDTO>
    {
        public WarenGruppeDTOListe() : base() { }
        public WarenGruppeDTOListe(IEnumerable<WarenGruppeDTO> items) : base(items) { }
    }
}