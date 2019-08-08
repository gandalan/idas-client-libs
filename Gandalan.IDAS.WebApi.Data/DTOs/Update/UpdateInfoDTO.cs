using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class UpdateInfoDTO
    {
        public DateTime KatalogArtikel { get; set; }
        public DateTime ProduktFamilien { get; set; }
        public DateTime ProduktGruppen { get; set; }
        public DateTime Varianten { get; set; }
        public DateTime UI { get; set; }
        public DateTime WerteListen { get; set; }
        public DateTime Farben { get; set; }
        public DateTime Scripts { get; set; }
        public DateTime FarbKuerzel { get; set; }
        public DateTime Oberflaechen { get; set; }
        public DateTime FarbGruppen { get; set; }
    }
}