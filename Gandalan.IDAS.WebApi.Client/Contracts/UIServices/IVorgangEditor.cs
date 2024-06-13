using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices;

public interface IVorgangEditor
{
    Task EditVorgang(Guid VorgangGuid);
    Task AddVorgang();
    Task AddVorgang(Guid KundeGuid);
}