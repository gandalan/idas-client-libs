using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.UIServices;

public interface IBelegPositionEditor
{
    Task AddPosition(BelegPositionDTO position);
    Task EditPosition(BelegPositionDTO position);
    Task EditPosition(Guid positionGuid);
}

public interface IBelegPositionEditorControl
{
    IBelegPositionEditorViewModel Model { get; }
}

public interface IBelegPositionEditorViewModel
{
    // Diese Felder müssen aus dem Editor-Viewmodel mal noch raus, weil kaufmännisch... refa!
    decimal AufAbSchlag { get; set; }
    decimal Einzelpreis { get; set; }
    decimal Gesamtpreis { get; set; }
    decimal Listenpreis { get; }
    decimal Menge { get; set; }
    decimal Rabatt { get; set; }

    Task LoadPositionByGuid(Guid positionGuid);
    Task LoadPosition(BelegPositionDTO position);

    void UpdateBelegPosition();
}