using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.AV
{
    public interface ISerienKapazitaetBerechnung
    {
        Task<IList<SerienKapazitaetInfo>> GetKapazitaetsBedarf(IList<SerieDTO> serien);
        Task<SerienKapazitaetInfo> GetKapazitaetsBedarf(SerieDTO serie);
    }
}
