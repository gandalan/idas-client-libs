using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.Rechnungen;

public interface IRechnungErstellenModul
{
    Task ShowRechnungErstellen();
}

public interface IRechnungAusgabeModul
{
    Task ShowPrintedRechnungAusgabe(Guid sammelrechnungGuid, DateTime? lastPrintDate);
    Task ShowRechnungAusgabe();
}