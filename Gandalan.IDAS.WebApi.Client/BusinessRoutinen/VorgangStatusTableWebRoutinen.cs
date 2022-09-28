using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class VorgangStatusTableWebRoutinen : WebRoutinenBase
    {
        public VorgangStatusTableWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }
                
        public string UpdateVorgangStatusTableForFunction(VorgangStatusTableDTO dto)
        {
            if (Login())
            {
                return Post("VorgangStatus/UpdateVorgangStatusTableForFunction", dto);
            }
            return null;
        }

        public IList<VorgangStatusTableDTO> GetNotCalculatedVorgangStatusTableForFunction()
        {
            if (Login())
            {
                return Get<IList<VorgangStatusTableDTO>>("VorgangStatus/GetNotCalculatedVorgangStatusTableForFunction");
            }
            return null;
        }
    }
}
