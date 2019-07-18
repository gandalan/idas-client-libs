using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IBelegAdresseEditor
    {
        Task EditAdresse(BeleganschriftDTO dto);

    }
}
