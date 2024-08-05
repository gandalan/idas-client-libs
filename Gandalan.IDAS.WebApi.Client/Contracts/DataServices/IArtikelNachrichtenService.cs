using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.DTOs.Nachrichten;

namespace Gandalan.IDAS.WebApi.Client.Contracts.DataServices;

public interface IArtikelNachrichtenService
{
    Task<List<ArtikelNachrichtDTO>> GetArtikelNachrichten();
}
