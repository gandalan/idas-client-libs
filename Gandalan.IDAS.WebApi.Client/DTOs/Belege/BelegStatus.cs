using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Belege
{
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
