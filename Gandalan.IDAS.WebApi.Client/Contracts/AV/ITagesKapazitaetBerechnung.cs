using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.AV
{
    public interface ITagesKapazitaetBerechnung
    {
        Task<TagesKapazitaetInfo> GetKapazitaetsBedarf(DateTime datum, bool includeStaendigeSerien = true);
    }
}
