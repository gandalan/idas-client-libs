using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ResetCacheVariantenListenWebRoutinen : WebRoutinenBase
    {
        public ResetCacheVariantenListenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public void Reset()
        {
            if (Login())
            {
                Put("ResetCacheVariantenListen", null);
            }
        }


        public async Task ResetAsync()
        {
            await Task.Run(() => Reset());
        }
    }
}
