using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// DTO für eine Lagerbuchung
    /// </summary>
    public class LagerbuchungDTO
    {
        public Guid KatalogArtikelGuid { get; set; }

        public Guid FarbGuid { get; set; }

        public float Betrag { get; set; }
    }
}
