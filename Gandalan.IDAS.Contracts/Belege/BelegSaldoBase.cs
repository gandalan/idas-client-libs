using System;

namespace Gandalan.IDAS.Contracts.Belege
{
    public class BelegSaldoBase
    {
        public Guid BelegSaldoGuid { get; set; }
        public int Reihenfolge { get; set; }
        public string Text { get; set; }
        public decimal Betrag { get; set; }
    }
}
