using System;
using System.Collections.Generic;
using System.Linq;

namespace Gandalan.IDAS.Contracts.Belege
{
    public abstract class BelegBase
    {
        public virtual Guid BelegGuid { get; set; }
        public long BelegNummer { get; set; }
        public int BelegJahr { get; set; }
        public WebApi.Data.DTOs.Belege.BelegArt BelegArt { get; set; }
        public DateTime BelegDatum { get; set; }
        public string BelegTitelUeberschrift { get; set; }
        public string BelegTitelZeile1 { get; set; }
        public string BelegTitelZeile2 { get; set; }
        public string Schlusstext { get; set; }
        public string ZahlungsBedingungen { get; set; }

        #region Salden
        public abstract IEnumerable<BelegSaldoBase> GetSalden();
        public abstract void AddOrUpdateSaldo(BelegSaldoBase saldo);
        public abstract void RemoveSaldo(BelegSaldoBase saldo);
        #endregion Salden

        #region Historie
        public abstract void AddHistorie(BelegHistorieBase eintrag);
        #endregion Historie

        #region Positionen
        public abstract IEnumerable<BelegPositionBase> GetPositionen();
        public abstract void AddOrUpdatePosition(BelegPositionBase position);
        public abstract void RemovePosition(BelegPositionBase position);

        public virtual BelegPositionBase GetPosition(Guid guid)
        {
            return GetPositionen().FirstOrDefault(p => p.BelegPositionGuid == guid);
        }

        public virtual BelegPositionBase GetPosition(int laufendeNummer)
        {
            return GetPositionen().FirstOrDefault(p => p.LaufendeNummer == laufendeNummer);
        }
        #endregion
    }
}
