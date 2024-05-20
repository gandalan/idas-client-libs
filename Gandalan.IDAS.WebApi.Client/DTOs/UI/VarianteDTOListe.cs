using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class VarianteDTOListe : ObservableCollection<VarianteDTO>
    {
        public VarianteDTOListe()
        {
        }

        public VarianteDTOListe(IEnumerable<VarianteDTO> items) : base(items)
        {
        }
    }
}
