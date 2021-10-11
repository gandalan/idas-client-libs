using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class PasswortAendernDTO
    {
        public string Benutzername { get; set; }
        public string AltesPasswort { get; set; }
        public string NeuesPasswort { get; set; }
    }
}
