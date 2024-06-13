using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices;

public interface IKundenBenutzerService
{
    Task SaveBenutzerAsync(KontaktDTO kunde, List<BenutzerDTO> benutzer);
    Task SaveBenutzerAsync(KontaktDTO kunde, BenutzerDTO benutzer, bool pwSenden, bool nlSenden);
    Task ToggleAppFreigabe(KontaktDTO kunde, bool aktivieren);
    Task RemoveBenutzerAsync(KontaktDTO kunde, BenutzerDTO benutzer);
}