using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.Client.Contracts.Vorgaenge;

public interface IBelegPositionItem
{
    VorgangDTO Vorgang { get; set; }
    BelegDTO Beleg { get; set; }
    BelegPositionDTO BelegPosition { get; set; }
    string PositionsNummer { get; set; }
    int LaufendeNummer { get; set; }
    string Variante { get; set; }
    decimal Einzelpreis { get; set; }
    decimal Menge { get; set; }
    decimal Gesamtpreis { get; set; }
    string Text { get; set; }
    string AnzeigeText { get; set; }
    string PulverCode { get; set; }
    string Serie { get; set; }
    DateTime StatusDatum { get; set; }
    bool IsDeleted { get; set; }
    bool IstAktiv { get; set; }
    bool IstAlternativ { get; set; }

    Task Load(BelegPositionDTO belegPositionDTO, VorgangDTO vorgangDTO, BelegDTO belegDTO);
}