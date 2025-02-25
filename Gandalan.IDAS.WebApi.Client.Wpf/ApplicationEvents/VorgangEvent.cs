using System;
using Gandalan.Client.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.Wpf.ApplicationEvents;

public class VorgangEvent(VorgangEventTypes eventType, VorgangDTO currentVorgang, Guid? newVorgang = null, BelegDTO beleg = null,
    BelegartWechselDTO belegartWechsel = null, KontaktDTO kontakt = null, BeleganschriftDTO belegAdresse = null,
    string neueBelegArt = null, BelegSaldoDTO saldo = null,
    VorgangHistorieDTO historienEintrag = null, BelegHistorieDTO belegHistorienEintrag = null, BelegPositionHistorieDTO positionsHistorienEintrag = null,
    string kommission = null, string terminwunsch = null, Guid belegGuid = default, BelegPositionDTO belegPosition = null) : IApplicationEvent
{
    public string EventType { get; } = eventType.ToString();

    public VorgangDTO CurrentVorgang { get; } = currentVorgang;
    public Guid? NewVorgang { get; } = newVorgang;
    public BelegDTO Beleg { get; } = beleg;
    public BelegPositionDTO BelegPosition { get; } = belegPosition;

    public BelegartWechselDTO BelegartWechsel { get; } = belegartWechsel;
    public string NeueBelegArt { get; } = neueBelegArt;

    public KontaktDTO Kontakt { get; } = kontakt;
    public BeleganschriftDTO BelegAdresse { get; } = belegAdresse;

    public BelegSaldoDTO Saldo { get; } = saldo;

    public VorgangHistorieDTO HistorienEintrag { get; } = historienEintrag;
    public BelegHistorieDTO BelegHistorienEintrag { get; } = belegHistorienEintrag;
    public BelegPositionHistorieDTO PositionsHistorienEintrag { get; } = positionsHistorienEintrag;

    public string Kommission { get; } = kommission;
    public string Terminwunsch { get; } = terminwunsch;
    public Guid BelegGuid { get; } = belegGuid;
}

public enum VorgangEventTypes
{
    BeforeLoad,
    Loaded,
    BeforeSave,
    Saved,
    BeforeSetAktuellerBeleg,
    AktuellerBelegSet,
    Reactivated,
    BeforeReactivate,
    BeforeChangeKontakt,
    KontaktChanged,
    BelegAdresseSet,
    BelegArtChanged,
    SaldoAdded,
    SaldoUpdated,
    SaldoRemoved,
    SelbstabholerSet,
    HistorieAdded,
    KommissionSet,
    Kommission2Set,
    TerminwunschSet,
    BelegDeleted,
    FremdfertigungActivated,
    FremdfertigungDeactivated,
    FremdfertigungProduzentSet
}

public enum VorgangEventReasons
{
    CreateOrEdit,
    Archive,
    Disposition
}
