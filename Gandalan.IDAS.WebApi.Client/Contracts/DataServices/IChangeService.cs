using Gandalan.IDAS.WebApi.Data.DTOs.Update;
using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IChangeService
    {
        Task<ChangeDTO[]> GetAll(string typeName, DateTime changedSince);
    }
}
