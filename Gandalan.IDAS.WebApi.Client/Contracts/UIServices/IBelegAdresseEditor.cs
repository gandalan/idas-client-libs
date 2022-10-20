using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IBelegAdresseEditor
    {
        Task<BeleganschriftDTO> EditAdresse(BeleganschriftDTO dto, KontaktDTO kontaktDto);
    }
}
