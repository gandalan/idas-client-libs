using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.DataServices
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
