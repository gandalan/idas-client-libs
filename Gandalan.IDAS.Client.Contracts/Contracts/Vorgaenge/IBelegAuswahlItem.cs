using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Vorgaenge
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
