using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class TemplateWebRoutinen : WebRoutinenBase
    {
        public TemplateWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

	    public TemplateDTO[] GetAll()
	    {
		    if (Login())
		    {
			    return Get<TemplateDTO[]>("Template");
		    }
		    return null;
	    }

	    public TemplateDTO GetTemplate(Guid id)
	    {
		    if (Login())
		    {
			    try
			    {
				    return Get<TemplateDTO>("Template?id=" + id.ToString());
			    }
			    catch
			    {
				    if (!IgnoreOnErrorOccured)
					    throw;
			    }
		    }
		    return null;
	    }

	    public string SaveTemplate(TemplateDTO dto)
	    {
		    if (Login())
		    {
			    return Put("Template/" + dto.TemplateGuid, dto);
		    }
		    return null;
	    }

	    public void DeleteTemplate(Guid templateGuid)
	    {
		    if (Login())
		    {
			    Delete("Template/" + templateGuid);
		    }
	    }


	    public async Task<TemplateDTO[]> GetAllAsync()
	    {
		    return await Task.Run(() => GetAll());
	    }
	    public async Task<TemplateDTO> GetTemplateAsync(Guid id)
	    {
		    return await Task.Run(() => GetTemplate(id));
	    }
	    public async Task SaveTemplateAsync(TemplateDTO dto)
	    {
		    await Task.Run(() => SaveTemplate(dto));
	    }
	    public async Task DeleteTemplateAsync(Guid templateGuid)
	    {
		    await Task.Run(() => DeleteTemplate(templateGuid));
	    }
	}
}
