using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.Printing
{
    public class ProduktionsLieferscheinData
    {
        public DateTime Liefertermin { get; set; }
        public bool ShowLiefertermin { get; set; } = true;
        public bool ShowAbsendeanschrift { get; set; }
        public bool ShowKommissionBarcode { get; set; }
        public bool UseTerminwunschAsLiefertermin { get; set; }
        public string Terminwunsch { get; set; }
        public bool ShowKommission2 { get; set; }
        public bool IstSelbstabholer { get; set; }
        public string Serie { get; set; }
        public string Vorgangsliste { get; set; }
        public bool ShowVorgangsListe { get; set; } = true;
        public string Absendeanschrift { get; set; }
        public string BarCodeTyp { get; set; }
        public string Vorgangsnummer { get; set; }
        public string DisplayVorgangsnummer { get; set; }
        public string VersandAdresse { get; set; }
        public bool VersandLandIsEUCountry { get; set; }
        public string Kommission { get; set; }
        public string Kommission2 { get; set; }
        public int GesamtAnzahlElemente { get; set; }
        public List<ProduktionsLieferscheinPositionData> Positionen { get; set; } = new();
        public List<ProduktionsLieferscheinPositionData> Artikel { get; set; } = new();
        public List<ProduktionsLieferscheinPacklisteData> Packliste { get; set; } = new();
    }
}
