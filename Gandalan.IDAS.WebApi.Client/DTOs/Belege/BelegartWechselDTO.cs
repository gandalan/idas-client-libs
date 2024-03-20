using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;
using Gandalan.IDAS.WebApi.Data.DTOs.Belege;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class BelegartWechselDTO
    {
        public Guid BelegGuid { get; set; }
        public IList<Guid> BelegPositionGuids { get; set; }
        public BelegArt NeueBelegArt { get; set; }
        public bool SaldenKopieren { get; set; }
        public RechnungsNummer RechnungsNummer { get; set; }
    }
}
