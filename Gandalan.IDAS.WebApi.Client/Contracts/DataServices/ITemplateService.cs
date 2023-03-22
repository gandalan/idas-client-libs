using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface ITemplateService
	{
        Task<TemplateDTO[]> GetAllAsync();
        Task SaveTemplate(TemplateDTO reportToSave);
        Task DeleteTemplate(TemplateDTO reportToDelete);
        Task<TemplateDTO> GetTemplate(Guid guid);
    }
}
