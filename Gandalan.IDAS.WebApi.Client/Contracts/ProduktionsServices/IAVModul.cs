using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices;

public interface IAVModul
{
    Task ShowAVPlanung(Func<Task> onShown = null);
}

public interface IAVDruckModul
{
    Task ShowAVDruck(Func<Task> onShown = null);

    Task ShowEinzelDruck(string VorgangsNummer, Func<Task> onShown = null);
}