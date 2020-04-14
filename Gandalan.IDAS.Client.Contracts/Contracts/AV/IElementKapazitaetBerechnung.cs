using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts.AV
{
    public interface IElementKapazitaetBerechnung
    {
        decimal GetKapazitaetsBedarf(BelegPositionDTO belegPosition, DateTime datum, SerieDTO serie);
    }
}
