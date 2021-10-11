using Gandalan.IDAS.WebApi.Data.DTOs.Update;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IChangeService
    {
        Task<ChangeDTO[]> GetAll(string typeName, DateTime changedSince);
    }
}
