using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.DTOs.SonderWuensche
{
    public class SonderWunschEigenschaftDTO
    {
        public string Bezeichnung { get; set; }
        public string Kuerzel { get; set; }
        public string GehoertZuProfilMitKuerzel { get; set; }
        public string InternerName { get; set; }
        public string Standard { get; set; }
        public string Liste { get; set; }
    }
}
