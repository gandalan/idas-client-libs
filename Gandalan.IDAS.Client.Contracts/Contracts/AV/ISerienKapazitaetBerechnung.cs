using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts.AV
{
    public interface ISerienKapazitaetBerechnung
    {
        SerienKapazitaetInfo GetKapazitaetsBedarf(SerieDTO datum);
    }
}
