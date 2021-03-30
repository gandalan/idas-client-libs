using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Vorgaenge
{
    public interface IProduktionsInfo
    {
        public string PCode { get; set; }
        public string Serie { get; set; }
        public DateTime ProduktionsDatum { get; set; }
        public DateTime LieferDatum { get; set; }
    }
}
