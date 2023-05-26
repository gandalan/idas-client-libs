using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BriefbogenWebRoutinen : WebRoutinenBase
    {
        public BriefbogenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<byte[]> BriefbogenLadenAsync() 
            => await GetDataAsync("Briefbogen");
    }
}
