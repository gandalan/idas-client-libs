using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.AV
{
    public interface ISerienKapazitaetBerechnung
    {
        Task<IList<SerienKapazitaetInfo>> GetKapazitaetsBedarf(IList<SerieDTO> serien);
        Task<SerienKapazitaetInfo> GetKapazitaetsBedarf(SerieDTO serie);
    }
}
