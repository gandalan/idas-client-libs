using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Vorgaenge
{
    public interface IProduktionsInfo
    {
        string PCode { get; set; }
        string Serie { get; set; }
        DateTime ProduktionsDatum { get; set; }
        DateTime LieferDatum { get; set; }
    }
}
