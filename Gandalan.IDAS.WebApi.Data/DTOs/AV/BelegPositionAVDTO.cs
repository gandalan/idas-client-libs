using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class BelegPositionAVDTO
    {
        public Guid BelegPositionAVGuid { get; set; }
        public Guid SerieGuid { get; set; }

        public Guid BelegPositionGuid { get; set; }
        public Guid VorgangGuid { get; set; }
        public Guid BelegGuid { get; set; }

        public DateTime Bereitgestellt { get; set; }
        public DateTime? Berechnet { get; set; }
        public bool IstBerechnet { get; set; }
        public bool IstProduziert { get; set; }
        public bool IstGeloescht { get; set; }
        public MaterialBeschaffungsJobStatiDTO Materialbeschaffungsstatus { get; set; }
        public bool HatSonderwuensche { get; set; }
        public string Variante { get; set; }
        public string Kommission { get; set; }
        public string Kunde { get; set; }
        public string Pcode { get; set; }

        public BelegPositionDTO Position { get; set; }
        public ProduktionsDatenDTO ProduktionsDaten { get; set; }
        public bool IstGedruckt { get; set; }

        public DateTime ChangedDate { get; set; }

        public BelegPositionAVDTO()
        {
            if (BelegPositionAVGuid.Equals(Guid.Empty))
                BelegPositionAVGuid = Guid.NewGuid();
        }

        public BelegPositionAVDTO(BelegPositionDTO position, string kunde, string kommission = null)
        {
            if (BelegPositionAVGuid.Equals(Guid.Empty))
                BelegPositionAVGuid = Guid.NewGuid();
            BelegPositionGuid = position.BelegPositionGuid;
            Bereitgestellt = DateTime.UtcNow;
            Berechnet = null;
            IstBerechnet = false;
            IstProduziert = false;
            HatSonderwuensche = !string.IsNullOrEmpty(position.Besonderheiten);
            Variante = position.Variante;
            Position = position;
            Kunde = kunde;
            Kommission = string.IsNullOrEmpty(kommission) ? position.PositionsKommission : kommission;
        }
    }
}
