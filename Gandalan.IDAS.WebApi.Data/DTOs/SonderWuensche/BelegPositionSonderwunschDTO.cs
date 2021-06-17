using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Data.DTO
{
    public class BelegPositionSonderwunschDTO
    {
        public string Wert { get; set; }
        public decimal Laenge { get; set; }
        public decimal Hoehe { get; set; }
        public string Typ { get; set; }
        public string Gruppe { get; set; }
        public string Farbe { get; set; }
        public float Aufpreis { get; set; }
        public string Bezeichnung { get; set; }
        public string Kuerzel { get; set; }
        public string GehoertZuProfilMitKuerzel { get; set; }
        public string InternerName { get; set; }
        public string Standard { get; set; }
        public string ListenName { get; set; }
        public Guid BelegPositionSonderwunschGuid { get; set; }
    }
}
