using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Gandalan.IDAS.WebApi.DTO;
using Gandalan.IDAS.WebApi.DTO.Gesamtbedarf;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Gesamtbedarf;
public interface IGesamtbedarfListe
{
    ObservableCollection<IGesamtMaterialbedarfItem> Bedarfe { get; set; }
    ObservableCollection<IGesamtMaterialbedarfItem> Fehlliste { get; set; }

    void Zusammenfassen(List<GesamtMaterialbedarfDTO> dtos, ZusammenfassungsOptionen optionen,
            bool stangenoptimierung);
}

public static class GesamtMaterialbedarfItemViewModelListExtensions
{
    public static List<GesamtMaterialbedarfDTO> ToDTOs(this IEnumerable<IGesamtMaterialbedarfItem> viewModels)
    {
        return viewModels.Select(vm => vm.ToDTO()).ToList();
    }
}
