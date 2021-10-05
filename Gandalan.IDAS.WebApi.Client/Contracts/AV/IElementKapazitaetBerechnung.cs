using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.AV
{
    public interface IElementKapazitaetBerechnung
    {
        Task<decimal> GetKapazitaetsBedarf(BelegPositionDTO belegPosition);
        Task<decimal> GetKapazitaetsBedarf(BelegPositionAVDTO belegPositionAV);
    }
}
