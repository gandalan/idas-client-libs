using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.Client.Common.Contracts.DataServices
{
    public interface ITemplateService
	{
        Task<TemplateDTO[]> GetAllAsync();
        Task SaveTemplate(TemplateDTO reportToSave);
        Task DeleteTemplate(TemplateDTO reportToDelete);
        Task<TemplateDTO> GetTemplate(Guid guid);
    }
}
