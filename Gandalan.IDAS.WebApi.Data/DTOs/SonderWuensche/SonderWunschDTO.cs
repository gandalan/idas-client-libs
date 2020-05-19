using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.DTOs.SonderWuensche
{
    public class SonderWunschDTO
    {
        public string Wert { get; set; }
        public string[] Listenwerte { get; set; }
        public decimal Laenge { get; set; }
        public string Farbe { get; set; }
    }
}
