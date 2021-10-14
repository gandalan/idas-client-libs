using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class ProduzentAktivierenDTO
    {
        public Guid FreischaltCode { get; set; }
        public string AdminEmail { get; set; }
        public int DongleNummer { get; set; }

    }
}
