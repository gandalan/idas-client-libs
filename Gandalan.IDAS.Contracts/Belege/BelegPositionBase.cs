using System;

namespace Gandalan.IDAS.Contracts.Belege
{
    public abstract class BelegPositionBase
    {
        public virtual Guid BelegPositionGuid { get; set; }
        public virtual Guid NachfolgeBelegPositionGuid { get; set; }
        public virtual Guid? VorgaengerBelegPositionGuid { get; set; }
        public virtual string PositionsNummer { get; set; }
        public virtual int LaufendeNummer { get; set; }
        public virtual DateTime ErfassungsDatum { get; set; }

        public virtual decimal Menge { get; set; }
        public virtual string MengenEinheit { get; set; }

        public virtual decimal Einzelpreis { get; set; }
        public virtual decimal Listenpreis { get; set; }
        public virtual bool IstBruttoEinzelpreis { get; set; }
        public virtual decimal Farbzuschlag { get; set; }
        public virtual bool IstFarbzuschlagManuell { get; set; }
        public virtual bool IstSonderfarbPosition { get; set; }
        public virtual decimal Rabatt { get; set; }
        public virtual decimal AufAbschlag { get; set; }
        public virtual decimal Steuersatz { get; set; }
        public virtual decimal Gesamtpreis { get; set; }
        public virtual bool IstBruttoGesamtpreis { get; set; }

        public virtual string Text { get; set; }
        public virtual string AngebotsText { get; set; }

        public virtual bool IstAlternativPosition { get; set; }
        public virtual int AlternativPositionZuNummer { get; set; }
        public virtual bool IstOptionalePosition { get; set; }
        public virtual bool IstAktiv { get; set; }
        public DateTime? ProduktionsDatum { get; set; }
        public DateTime? LieferDatum { get; set; }
        public DateTime? ProduktionsAuftragErstellt { get; set; }

        public virtual bool IstFremdfertigung { get; set; }
        public virtual Guid? FremdfertigungMandantGuid { get; set; }
    }
}
