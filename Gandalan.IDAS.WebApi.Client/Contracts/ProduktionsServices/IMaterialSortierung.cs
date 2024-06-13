using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.ProduktionsServices;

public interface IMaterialSortierung
{
    Task<List<KeyValuePair<string, MaterialbedarfDTO>>> AblageFachSortierung(SerieDTO serie);

    List<KeyValuePair<string, MaterialbedarfDTO>> AblageFachSortierung(IList<BelegPositionAVDTO> avData, IList<MaterialbedarfDTO> materialListe);

    Task<Dictionary<string, MaterialbedarfDTO>> SchnittSortierung(SerieDTO serie);
    Dictionary<string, MaterialbedarfDTO> SchnittSortierung(IList<BelegPositionAVDTO> avData);

    Dictionary<string, MaterialbedarfDTO> SchnittSortierung(IList<BelegPositionAVDTO> avData, IList<MaterialbedarfDTO> materialListe);

    string KuerzelSortierung(string kuerzel);
}