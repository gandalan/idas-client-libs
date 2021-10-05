using Gandalan.IDAS.WebApi.Data.DTOs.Belege;
using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class BelegartWechselDTO
    {
        public Guid BelegGuid { get; set; }
        public IList<Guid> BelegPositionGuids { get; set; }
        public BelegArt NeueBelegArt { get; set; }
        public bool SaldenKopieren { get; set; } = false;
    }
}
