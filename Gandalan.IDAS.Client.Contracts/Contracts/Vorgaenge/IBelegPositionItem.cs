using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts.Contracts.Vorgaenge
{
    public interface IBelegPositionItem
    {
        VorgangDTO Vorgang { get; }
        BelegDTO Beleg { get; }
        BelegPositionDTO BelegPosition { get; }
        string PositionsNummer { get; }
        int LaufendeNummer { get; }
        string Variante { get; }
        decimal Einzelpreis { get; }
        decimal Menge { get; }
        decimal Gesamtpreis { get; }
        string Text { get; }
        string AnzeigeText { get; }
        string Status { get; }
        string PCode { get; }
        string Serie { get; }
        DateTime StatusDatum { get; }
        bool IsDeleted { get; set; }
        bool IstAktiv { get; }
        bool IstAlternativ { get; }

        void Load(BelegPositionDTO belegPositionDTO, VorgangDTO vorgangDTO, BelegDTO belegDTO, string pcode, string serie);
        void SetStatus();
    }
}
