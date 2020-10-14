using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Reports
{
    public class SerienSaegelistenProfilgruppeSchnittDataDTO
    {
        // = true wenn Anzahl in Profilgruppe mit gleicher Länge > Profilanzahl in AnzahlProfile
        public bool IsX { get; set; }
        // Gesamtanzahl der Profile
        public int ValueX { get; set; }
        // ...l} oder ...r}
        public bool IsSenkrecht { get; set; }
        public int AnzahlProfile { get; set; }
        public float SaegeMassEinstellung { get; set; }
        public string LaufendeEtikettenNummer { get; set; }
        public bool IsSonderEtikett { get; set; }
        //True = Wenn Variante SP1/40 oder SP1/41
        public bool IsE { get; set; }
        //Serienname + Vorgangsnummer + Positionsnummer
        public string Kennzeichen { get; set; }
        public string VorgangsNummer { get; set; }
        public string PositionsNummer { get; set; }
        public string GemeinsameEtikettenNummer { get; set; }
        public float ProfilMass { get; set; }
        public string ZuschnittWinkel { get; set; }
        public string FachNummer { get; set; }
        public string InternerName { get; set; }

    }
}
