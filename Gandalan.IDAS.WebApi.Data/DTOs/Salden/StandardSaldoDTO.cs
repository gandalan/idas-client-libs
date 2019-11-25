using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Salden
{
    public class StandardSaldoDTO
    {
        public Guid StandardSaldoGuid { get; set; }
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
        public bool IsNettoSaldo { get; set; }
        /// <summary>
        /// Text für die Anzeige
        /// </summary>
        public string Text { get; set; }
        public DateTime? GueltigAb { get; set; }
        public DateTime? GueltigBis { get; set; }
    }
}
