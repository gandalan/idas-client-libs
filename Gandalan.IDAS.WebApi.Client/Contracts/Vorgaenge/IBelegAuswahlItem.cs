using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.Client.Contracts.Vorgaenge
{
    public interface IBelegAuswahlItem
    {
        BelegDTO Beleg { get; }
        VorgangDTO Vorgang { get; }

        string Titel { get; }
        DateTime ErstellDatum { get; }
        IList<BelegSaldoDTO> Salden { get; }
        IList<BelegPositionDTO> Positionen { get; }
        bool IstKopiert { get; }
    }
}
