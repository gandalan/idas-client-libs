using Gandalan.IDAS.WebApi.Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Data.DTOs.SonderWuensche
{
    public class BelegPositionSonderwunschGruppeDTO
    {
        public string Name { get; set; }
        public BelegPositionSonderwunschDTO[] Items { get; set; }
    }
}
