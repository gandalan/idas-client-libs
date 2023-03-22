using Gandalan.IDAS.WebApi.DTO;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.AV
{
    public interface IElementKapazitaetBerechnung
    {
        Task<decimal> GetKapazitaetsBedarf(BelegPositionDTO belegPosition);
        Task<decimal> GetKapazitaetsBedarf(BelegPositionAVDTO belegPositionAV);
    }
}
