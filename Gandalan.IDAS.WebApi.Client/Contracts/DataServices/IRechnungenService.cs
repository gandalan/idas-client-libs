using Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Contracts.DataServices
{
    public interface IRechnungenService
    {
        Task<List<FakturierbarerBelegeDTO>> GetABFakturierbarListeAsync();
    }
}
