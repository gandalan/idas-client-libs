using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.Util;
using PropertyChanged;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class BelegSaldoDTO : IDTOWithApplicationSpecificProperties
    {
        public Guid BelegSaldoGuid { get; set; }
        public int Reihenfolge { get; set; }
        /// <summary>
        /// Text für die Anzeige
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Der eigentlich Saldenwert.
        /// </summary>
        public decimal Betrag { get; set; }
        /// <summary>
        /// Der Wert, den der Anwender eingegeben hat, z.B. 5%
        /// </summary>
        public decimal Wert { get; set; }
        /// <summary>
        /// Zulässige Werte: "Abschlag", "Zuschlag", "Betrag"
        /// </summary>
        public string Typ { get; set; }
        /// <summary>
        /// Zulässige Werte: "Prozentual", "Absolut"
        /// </summary>
        public string Art { get; set; }
        /// <summary>
        /// Zulässige Werte: "Saldo", "StandardSaldo", "Warenwert", "Mehrwertsteuer",
        /// "Gesamtbetrag", "Endbetrag", "Farbe"  
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Zulässige Werte: "Unbekannt", "ManuelleEingabe", "AutoEingabe", "AufAnfrage"
        /// </summary>
        public string SaldenStatus { get; set; }
        public bool IstInaktiv { get; set; }
        /// <summary>
        /// In diesem Tag können belibige interne Informationen als String gespeichert werden.
        /// </summary>
        public string Tag { get; set; }

        public Dictionary<string, PropertyValueCollection> ApplicationSpecificProperties { get; set; }
    }
}
