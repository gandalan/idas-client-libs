using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices;

public interface IUvKundeEditor : ILockedPanel
{
    Task EditKunde(Guid kundeGuid);
}
