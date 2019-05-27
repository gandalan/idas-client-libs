using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.DataServices
{
    public interface IUpdateInfoService
    {
        Task<UpdateInfoDTO> Get();
    }
}
