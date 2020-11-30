using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IMaterialBestellungExport
    {
        Task Export(IList<MaterialBeschaffungsJobDTO> jobs, string extension, string path);
        Task Send(IList<MaterialBeschaffungsJobDTO> jobs, string extension, string email);
    }
}
