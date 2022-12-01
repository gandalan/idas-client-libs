using System;

namespace Gandalan.IDAS.Contracts.Belege
{
    public class BelegHistorieBase
    {
        public Guid BelegHistorieGuid { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime Zeitstempel { get; set; }
        public virtual string Benutzer { get; set; }

        public BelegHistorieBase()
        {
            BelegHistorieGuid = Guid.NewGuid();
            Zeitstempel = DateTime.UtcNow;
        }
    }

    public enum BelegStatus
    {
        Unbekannt = 0,
        Erfasst = 10,
        Geloescht = 20,
        AngebotAngefragt = 30,
        Bestellt = 40,
        AuftragBestaetigt = 50,
        InProduktion = 60,
        ProduktionAbgeschlossen = 70,
        VersandVorbereitet = 80,
        VersandAusgefuehrt = 90,
        WareAusgeliefert = 100,
        Reklamation = 110,
        BestellungAbgeschlossen = 120,
        Fakturiert = 130,
        Storniert = 140,
        Importiert = 150,
        BelegKopiert = 160
    }
}
