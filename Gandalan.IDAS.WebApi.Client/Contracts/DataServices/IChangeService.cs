using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Data.DTOs.Update;

namespace Gandalan.Client.Contracts.DataServices;

public interface IChangeService
{
    Task<ChangeDTO[]> GetAll(string typeName, DateTime changedSince);
}