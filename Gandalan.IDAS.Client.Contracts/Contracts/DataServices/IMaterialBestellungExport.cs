using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IMaterialBestellungExport
    {
        Task<bool> Export(IList<MaterialbedarfDTO> material, string extension, string path);
        Task<bool> Send(IList<MaterialbedarfDTO> material, string extension, string email);
    }
}
