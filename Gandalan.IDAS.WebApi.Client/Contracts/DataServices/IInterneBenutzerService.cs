using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IInterneBenutzerService
    {
        Task<BenutzerDTO[]> GetAllAsync(Guid mandantGuid);
        Task<BenutzerDTO> GetBenutzerAsync(Guid benutzerGuid);
        Task SaveBenutzer(BenutzerDTO benutzer);
        Task PasswortReset(string emailAdresse);
        Task RequestNewsletterOptinAsync(Guid benutzerGuid);
    }
}
