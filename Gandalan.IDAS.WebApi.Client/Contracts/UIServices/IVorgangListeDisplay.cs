using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices;

public interface IVorgangListeDisplay
{
    Task DisplayVorgaenge();
    Task DisplayVorgaengeByKunde(Guid kundeGuid);
}